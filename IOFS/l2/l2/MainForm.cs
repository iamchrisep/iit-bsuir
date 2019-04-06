using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace l2
{
    public partial class MainForm : Form
    {
        private string currentFolder;
        List<string> wordsForSearch;
        public MainForm()
        {
            InitializeComponent();
            wordsForSearch = new List<string>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFolder = folderBrowserDialog1.SelectedPath;
                textBox2.Text = currentFolder;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wordsForSearch.Clear();
            dataGridView1.Rows.Clear();
            string src = textBox1.Text;
            string[] w = src.Split();
            foreach (string str in w)
            {
                string tmp = str.Trim('\'', '\"', '.', ',', ';', ':', '?', '!', '-', '_', '(', ')', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0');
                tmp = tmp.ToLowerInvariant();
                if ((tmp != "")&&(!wordsForSearch.Contains(tmp)))
                {
                    wordsForSearch.Add(tmp);
                }
            }
            DirectoryInfo di = new DirectoryInfo(currentFolder);
            FileInfo[] files = di.GetFiles("*.txt");
            //вывод имен файлов
            for (int i = 0; i <= files.Length - 1; i++)
            {
                StatGenerator sg = new StatGenerator(files[i].FullName);
                Dictionary<string,int> dic = sg.GetStatistics();
                bool chk = false;
                foreach (string str in wordsForSearch)
                {
                    if (dic.ContainsKey(str))
                    {
                        //MessageBox.Show(str + ';' + ((double)dic[str] / sg.numWords).ToString() + ';' + files[i].FullName);
                        if (((double)dic[str] / sg.numWords < 0.95) && ((double)dic[str] / sg.numWords > 0.001))
                            chk = true;
                    }
                }
                /////
                if (chk)
                {
                    dataGridView1.Rows.Add(new DataGridViewRow());
                    dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0].Value = files[i].FullName;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            p.Start();
        }
    }
}
