using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace l4
{
    public partial class Archiving : Form
    {
        class TreeNode
        {
            public TreeNode LeftChild = null;
            public TreeNode RightChild = null;
            public TreeNode Parent = null;
            public int Value = -1;
            public int Freq = -1;
            public List<byte> Code = new List<byte>();
            public TreeNode(int value, int freq)
            {
                Value = value;
                Freq = freq;
            }
            public TreeNode()
            {
            }
        }
        public Archiving()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    using (StreamWriter sw = new StreamWriter(ofd.FileName + ".haf"))
                    {
                        List<int> freq = new List<int>();
                        List<byte> codes = new List<byte>();
                        for (int i = 0; i < 256; i++)
                        {
                            codes.Add((byte)i);
                            freq.Add(0);
                        }
                        List<byte> text = new List<byte>();
                        int b = sr.BaseStream.ReadByte();
                        do
                        {
                            text.Add((byte)b);
                            freq[b]++;
                            b = sr.BaseStream.ReadByte();
                        }
                        while (b != -1);
                        for (int i = 0; i < 256; i++)
                            for (int j = 255; j > i; j--)
                                if (freq[j - 1] > freq[j])
                                {
                                    int x = freq[j - 1];
                                    freq[j - 1] = freq[j];
                                    freq[j] = x;
                                    byte a = codes[j - 1];
                                    codes[j - 1] = codes[j];
                                    codes[j] = a;
                                }
                        while (freq[0] == 0)
                        {
                            freq.RemoveAt(0);
                            codes.RemoveAt(0);
                        }
                        List<TreeNode> list = new List<TreeNode>();
                        List<TreeNode> copy = new List<TreeNode>();
                        for (int i = 0; i < freq.Count; i++)
                        {
                            TreeNode treeNode = new TreeNode(codes[i], freq[i]);
                            list.Add(treeNode);
                            copy.Add(treeNode);
                        }
                        while (list.Count > 1)
                        {
                            TreeNode tn = new TreeNode(-1, list[0].Freq + list[1].Freq);
                            tn.LeftChild = list[0];
                            tn.RightChild = list[1];
                            list[0].Parent = tn;
                            list[1].Parent = tn;
                            list.RemoveAt(0);
                            list.RemoveAt(0);
                            int pos = 0;
                            while ((pos < list.Count) && (list[0].Freq < tn.Freq))
                            {
                                pos++;
                            }
                            list.Insert(pos, tn);
                        }
                        TreeNode root = list[0];
                        if (copy.Count == 1)
                            copy[0].Code.Insert(0, 0);
                        else
                        {
                            for (int i = 0; i < copy.Count; i++)
                            {
                                TreeNode tmp = copy[i];
                                while (tmp != root)
                                {
                                    if (tmp.Parent.LeftChild == tmp)
                                        copy[i].Code.Insert(0, 0);
                                    if (tmp.Parent.RightChild == tmp)
                                        copy[i].Code.Insert(0, 1);
                                    tmp = tmp.Parent;
                                }
                            }
                        }
                        BitArray ba = new BitArray(text.Count * 8 * 5);
                        int count = 0;
                        for (int i = 0; i < text.Count; i++)
                        {
                            int j = 0;
                            while (copy[j].Value != text[i])
                                j++;
                            for (int k = 0; k < copy[j].Code.Count; k++)
                            {
                                ba.Set(count, copy[j].Code[k] == 1);
                                count++;
                            }
                        }
                        byte[] result = new byte[text.Count * 5];
                        ba.CopyTo(result, 0);
                        sw.BaseStream.WriteByte((byte)(count / (256 * 256 * 256)));
                        sw.BaseStream.WriteByte((byte)(count / (256 * 256) % 256));
                        sw.BaseStream.WriteByte((byte)(count / 256 % 256));
                        sw.BaseStream.WriteByte((byte)(count % 256));
                        sw.BaseStream.WriteByte((byte)(copy.Count / 256));
                        sw.BaseStream.WriteByte((byte)(copy.Count % 256));
                        
                        for (int i = 0; i < copy.Count; i++)
                        {
                            sw.BaseStream.WriteByte((byte)copy[i].Value);
                            sw.BaseStream.WriteByte((byte)(copy[i].Freq / (256 * 256 * 256)));
                            sw.BaseStream.WriteByte((byte)(copy[i].Freq / (256 * 256) % 256));
                            sw.BaseStream.WriteByte((byte)(copy[i].Freq / 256 % 256));
                            sw.BaseStream.WriteByte((byte)(copy[i].Freq % 256));
                        }
                        
                        for (int i = 0; i < count / 8 + 1; i++)
                        {
                            sw.BaseStream.WriteByte(result[i]);
                        }
                         
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "HAF архив (*.haf)|*.haf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName.Substring(0, ofd.FileName.Length - 4);
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        int count = 256 * 256 * 256 * sr.BaseStream.ReadByte();
                        count += 256 * 256 * sr.BaseStream.ReadByte();
                        count += 256 * sr.BaseStream.ReadByte();
                        count += sr.BaseStream.ReadByte();
                        int treeSize = 256 * sr.BaseStream.ReadByte();
                        treeSize += sr.BaseStream.ReadByte();
                        List<TreeNode> list = new List<TreeNode>();
                        List<TreeNode> copy = new List<TreeNode>();
                        for (int i = 0; i < treeSize; i++)
                        {
                            int value = sr.BaseStream.ReadByte();
                            int fr = 256 * 256 * 256 * sr.BaseStream.ReadByte();
                            fr += 256 * 256 * sr.BaseStream.ReadByte();
                            fr += 256 * sr.BaseStream.ReadByte();
                            fr += sr.BaseStream.ReadByte();
                            TreeNode treeNode = new TreeNode(value, fr);
                            list.Add(treeNode);
                            copy.Add(treeNode);
                        }
                        while (list.Count > 1)
                        {
                            TreeNode tn = new TreeNode(-1, list[0].Freq + list[1].Freq);
                            tn.LeftChild = list[0];
                            tn.RightChild = list[1];
                            list[0].Parent = tn;
                            list[1].Parent = tn;
                            list.RemoveAt(0);
                            list.RemoveAt(0);
                            int pos = 0;
                            while ((pos < list.Count) && (list[0].Freq < tn.Freq))
                            {
                                pos++;
                            }
                            list.Insert(pos, tn);
                        }
                        TreeNode root = list[0];
                        if (copy.Count == 1)
                            copy[0].Code.Insert(0, 0);
                        else
                        {
                            for (int i = 0; i < copy.Count; i++)
                            {
                                TreeNode tmp = copy[i];
                                while (tmp != root)
                                {
                                    if (tmp.Parent.LeftChild == tmp)
                                        copy[i].Code.Insert(0, 0);
                                    if (tmp.Parent.RightChild == tmp)
                                        copy[i].Code.Insert(0, 1);
                                    tmp = tmp.Parent;
                                }
                            }
                        }
                        byte[] text = new byte[count / 8 + 1];
                        for (int i = 0; i < text.Length; i++)
                            text[i] = (byte)sr.BaseStream.ReadByte();
                        BitArray ba = new BitArray(text);
                        TreeNode node = root;
                        for (int i = 0; i < count; i++)
                        {
                            if (copy.Count == 1)
                            {
                                sw.BaseStream.WriteByte((byte)node.Value);
                            }
                            else
                            {
                                if (ba[i])
                                {
                                    node = node.RightChild;
                                }
                                if (!ba[i])
                                {
                                    node = node.LeftChild;
                                }
                                if (node.Value >= 0)
                                {
                                    sw.BaseStream.WriteByte((byte)node.Value);
                                    node = root;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
