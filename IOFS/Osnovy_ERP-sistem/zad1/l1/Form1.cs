using System;              
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace l1
{
    public partial class Form1 : Form
    {
        List<string> wordsq = new List<string>(); 
        public double zipfLaw1;
        public double zipfLaw2;

        public double temp;

        public double extra;

        private void Form1_Resize(object sender, EventArgs e)
        {
            chart1.SetBounds(8, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);
            chart2.SetBounds(this.Size.Width / 2 + 5, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            chart1.SetBounds(8, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);
            chart2.SetBounds(this.Size.Width / 2 + 5, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);

            var col1 = new DataGridViewColumn();
            col1.HeaderText = "Словоформа";
            col1.Name = "word";
            col1.ReadOnly = true;
            col1.Resizable = DataGridViewTriState.True;
            col1.Width = 150;
            col1.CellTemplate = new DataGridViewTextBoxCell();

            var col2 = new DataGridViewColumn();
            col2.HeaderText = "Повторений";
            col2.Name = "repeats";
            col2.ReadOnly = true;
            col2.Resizable = DataGridViewTriState.True;
            col2.Width = 50;
            col2.CellTemplate = new DataGridViewTextBoxCell();

            var col3 = new DataGridViewColumn();
            col3.HeaderText = "Ранг";
            col3.Name = "rank";
            col3.ReadOnly = true;
            col3.Resizable = DataGridViewTriState.True;
            col3.Width = 50;
            col3.CellTemplate = new DataGridViewTextBoxCell();

            var col4 = new DataGridViewColumn();
            col4.HeaderText = "Частота";
            col4.Name = "freq";
            col4.ReadOnly = true;
            col4.Resizable = DataGridViewTriState.True;
            col4.Width = 50;
            col4.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            List<int> ranks = new List<int>();
            SortedDictionary<int, int> numRanks = new SortedDictionary<int, int>();
            OpenFileDialog ofd = new OpenFileDialog();
            int numWords = 0;
            ofd.Filter = "Text files(*.txt)|*.txt";
            stop_l("D:\\Сессия\\Основы ERP-систем\\texts\\text!.txt");
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] w = s.Split();
                    foreach (string str in w)
                    {
                        string tmp = str.Trim('\'', '\"', '.', ',', ';', ':',
                            '?', '!', '-', '_', '-', '+', '=', '/','*', '–',
                            '(', ')', '1', '2', '3', '4', '5', '6', '7',
                            '8', '9', '0', '—');
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
                foreach (KeyValuePair<string, int> k in words)
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

                List<KeyValuePair<string, int>> wordsList = words.ToList();

                wordsList.Sort(
                    delegate(KeyValuePair<string, int> pair1,
                    KeyValuePair<string, int> pair2)
                    {
                        return pair1.Value.CompareTo(pair2.Value);
                    });
                wordsList.Reverse();

                StreamWriter sw = new StreamWriter(ofd.FileName + "_keywords.log", false, Encoding.UTF8);
                int _beg = ranks[(int)(0 * (double)ranks.Count)];
                int _end = ranks[(int)(1 * (double)ranks.Count)-1];
                if (checkBox1.Checked)
                {
                    sw.WriteLine("Количество слов:" + words.Count.ToString());
                }

               int lastrang = 0;
               int lastRep = -122;

               dataGridView1.Rows.Clear();
                foreach (KeyValuePair<string, int> k in wordsList)
                {
                    if ((k.Value <= _beg) && (k.Value >= _end)&&(!wordsq.Contains(k.Key)))
                    {
                        if (checkBox1.Checked && lastrang<2000)
                        {
                            int rank = k.Value == lastRep ? lastrang : ++lastrang;
                            lastRep = k.Value;
                            dataGridView1.Rows.Add(k.Key, k.Value, rank, (double)k.Value / (double)numWords);
                        }
                        else
                        {
                            sw.WriteLine(k.Key);
                        }
                    }
                } 
                sw.Close();
                System.Windows.Forms.DataVisualization.Charting.Series DataSer1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                DataSer1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                DataSer1.Color = Color.Green;
                chart1.Series.Clear();
                System.Windows.Forms.DataVisualization.Charting.Series DataSer2 = new System.Windows.Forms.DataVisualization.Charting.Series();
                DataSer2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                DataSer2.Color = Color.Green;
                chart2.Series.Clear();
                double ZipfC1 = 0;
                double ZipfC2 = 0;                             
        
                for (int i = 0; i <= ranks.Count - 1; i++)
                {
                    ZipfC1 += (ranks[i] * (double)(i + 1) / numWords);
                    DataSer1.Points.AddXY(i + 1, (double)ranks[i] / numWords);                                         
                }
                foreach (KeyValuePair<int, int> kvp in numRanks)
                {
                    if (kvp.Key <= 100)
                    {
                        DataSer2.Points.AddXY(kvp.Key, kvp.Value);
                        ZipfC2 += kvp.Key * (double)kvp.Value / numWords;
                    }
                }

                

                ZipfC1 /= ranks.Count;
                ZipfC2 /= numRanks.Count;
                chart1.ResetAutoValues();
                chart1.Series.Add(DataSer1);
                chart2.ResetAutoValues();
                chart2.Series.Add(DataSer2);
                label1.Text = "Константа Зипфа для первого закона: " + ZipfC1.ToString();
                label2.Text = "Константа Зипфа для второго закона: " + ZipfC2.ToString();
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }


        public void stop_l (string str_n)
        {
            
            StreamReader sr = new StreamReader(str_n);
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] w = s.Split();
                foreach (string str in w)
                {
                    string tmp = str.Trim('\'');
                    tmp = tmp.ToLowerInvariant();
                    if (tmp != "")
                    {
                        wordsq.Add(tmp);
                    }
                }
            }
            sr.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
