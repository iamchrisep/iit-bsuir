using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace l2
{
    public partial class MainForm : Form
    {
        private string currentFolder = "D:\\Сессия\\Основы ERP-систем\\texts";
        private List<string> wordsForSearch;
        private List<string> wordsq = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            wordsForSearch = new List<string>();
            textBox2.Text = currentFolder;
        }
        /// <summary>
        /// Обзор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFolder = folderBrowserDialog1.SelectedPath;
                textBox2.Text = currentFolder;
            }
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            wordsForSearch.Clear();
            dataGridView1.Rows.Clear();
            var src = textBox1.Text;
            var w = src.Split();
            foreach (var str in w)
            {
                var tmp = str.Trim('\'', '\"', '.', ',', ';', ':', '?', '!', '-', '_', '(', ')', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0');
                tmp = tmp.ToLowerInvariant();
                if ((tmp != "")&&(!wordsForSearch.Contains(tmp)))
                {
                    wordsForSearch.Add(tmp);
                }
            }
            var di = new DirectoryInfo(currentFolder);
            var files = di.GetFiles("*.txt");

            for (var i = 0; i <= files.Length - 1; i++)
            {
                var sg = new StatGenerator(files[i].FullName);
                var dic = sg.GetStatistics();
                var chk = false;
                foreach (var str in wordsForSearch)
                {
                    if (dic.ContainsKey(str))
                    {

                        //if (((double)dic[str] / sg.numWords < 0.95) && ((double)dic[str] / sg.numWords > 0.001))
                            chk = true;
                    }
                }

                if (chk)
                {
                    dataGridView1.Rows.Add(new DataGridViewRow());
                    dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0].Value = files[i].FullName;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var p = new System.Diagnostics.Process
            {
                StartInfo = {FileName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()}
            };
            p.Start();
        }
        /// <summary>
        /// Выбор образца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var words = new Dictionary<string, int>();
            var ranks = new List<int>();
            var numRanks = new SortedDictionary<int, int>();
            var ofd = new OpenFileDialog();
            var numWords = 0;
            ofd.Filter = "Text files(*.txt)|*.txt";
            stop_l("D:\\Сессия\\Основы ERP-систем\\texts\\text!.txt");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    var s = sr.ReadLine();
                    var w = s.Split();
                    foreach (var str in w)
                    {
                        var tmp = str.Trim('\'', '\"', '.', ',', ';', ':',
                            '?', '!', '-', '_',
                            '(', ')', '1', '2', '3', '4', '5', '6', '7',
                            '8', '9', '0');
                        tmp = tmp.ToLowerInvariant();
                        if (tmp != "")
                        {
                            numWords++;
                            if (words.ContainsKey(tmp))
                            {
                                words[tmp]++;
                            }
                            else
                            {
                                words.Add(tmp, 1);
                            }
                        }
                    }
                }
                sr.Close();
                foreach (var k in words)
                {
                    if (!ranks.Contains(k.Value))
                    {
                        ranks.Add(k.Value);
                    }
                    if (numRanks.ContainsKey(k.Value))
                    {
                        numRanks[k.Value]++;
                    }
                    else
                    {
                        numRanks.Add(k.Value, 1);
                    }
                }
                ranks.Sort();
                ranks.Reverse();

                var wordsList = words.ToList();

                wordsList.Sort(
                    delegate(KeyValuePair<string, int> pair1,
                    KeyValuePair<string, int> pair2)
                    {
                        return pair1.Value.CompareTo(pair2.Value);
                    });
                wordsList.Reverse();

                var sw = new StreamWriter(ofd.FileName + "_keywords.log", false, Encoding.UTF8);
                var _beg = ranks[(int)(0.3 * (double)ranks.Count)];
                var _end = ranks[(int)(0.5 * (double)ranks.Count)];

                foreach (var k in wordsList)
                {
                    if ((k.Value <= _beg) && (k.Value >= _end) && (k.Key.Length > 2) && (!wordsq.Contains(k.Key)))
                    {
                        textBox1.Text += k.Key + " ";
                    }
                }
                sw.Close();
                double ZipfC1 = 0;
                double ZipfC2 = 0;
                for (var i = 0; i <= ranks.Count - 1; i++)
                {
                    ZipfC1 += (ranks[i] * (double)(i + 1) / numWords);
                }
                foreach (var kvp in numRanks)
                {
                    if (kvp.Key <= 100)
                    {
                        ZipfC2 += kvp.Key * (double)kvp.Value / numWords;
                    }
                }
                ZipfC1 /= ranks.Count;
                ZipfC2 /= numRanks.Count;
            }
        }

        public void stop_l(string str_n)
        {

            var sr = new StreamReader(str_n);
            while (!sr.EndOfStream)
            {
                var s = sr.ReadLine();
                var w = s.Split();
                foreach (var str in w)
                {
                    var tmp = str.Trim('\'');
                    tmp = tmp.ToLowerInvariant();
                    if (tmp != "")
                    {
                        wordsq.Add(tmp);
                    }
                }
            }
            sr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
