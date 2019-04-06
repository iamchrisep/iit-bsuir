using System;                   //jeunesse@inbox.ru
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
        public Form1()
        {
            InitializeComponent();
            chart1.SetBounds(8, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);
            chart2.SetBounds(this.Size.Width / 2 + 5, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            List<int> ranks = new List<int>();
            SortedDictionary<int, int> numRanks = new SortedDictionary<int, int>();
            OpenFileDialog ofd = new OpenFileDialog();
            int numWords = 0;
            ofd.Filter = "Text files(*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] w = s.Split();
                    foreach (string str in w)
                    {
                        string tmp = str.Trim('\'', '\"', '.', ',', ';', ':', '?', '!', '-', '_', '(', ')', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0');
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
                        numRanks.Add(k.Value,1);
                    }
                }
                ranks.Sort();
                ranks.Reverse();
                StreamWriter sw = new StreamWriter(ofd.FileName + "_keywords.log",false,Encoding.UTF8);
                int _beg = ranks[(int)(0.4*(double)ranks.Count)];
                int _end = ranks[(int)(0.6* (double)ranks.Count)];
                //MessageBox.Show(_beg.ToString() + ';' + _end.ToString());
                foreach (KeyValuePair<string, int> k in words)
                {
                    //sw.WriteLine(k.Key + ';' + k.Value);
                    
                    if ((k.Value <= _beg) && (k.Value >= _end))
                    {
                        sw.WriteLine(k.Key);
                    }
                     
                }
                sw.Close();
                System.Windows.Forms.DataVisualization.Charting.Series DataSer1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                DataSer1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                DataSer1.Color = Color.Red;
                chart1.Series.Clear();
                System.Windows.Forms.DataVisualization.Charting.Series DataSer2 = new System.Windows.Forms.DataVisualization.Charting.Series();
                DataSer2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                DataSer2.Color = Color.Red;
                chart2.Series.Clear();
                double ZipfC1 = 0;
                double ZipfC2 = 0;
                for (int i = 0; i <= ranks.Count - 1; i++)
                {
                    ZipfC1 +=(ranks[i]*(double)(i+1)/numWords);
                    DataSer1.Points.AddXY(i + 1, (double)ranks[i] / numWords);
                }
                foreach (KeyValuePair<int,int> kvp in numRanks)
                {
                    if (kvp.Key <= 100)
                    {
                        DataSer2.Points.AddXY(kvp.Key, kvp.Value);
                        ZipfC2 += kvp.Key * (double)kvp.Value/numWords;
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            chart1.SetBounds(8, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);
            chart2.SetBounds(this.Size.Width / 2 + 5, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);
        }
    }
}
