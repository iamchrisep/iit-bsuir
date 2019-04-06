using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace l1
{
    public partial class Form2 : Form
    {
        List<string> wordsq = new List<string>();
        public double zipfLaw1;
        public double zipfLaw2;

        public double temp;

        public double extra;

        public Form2()
        {
            InitializeComponent();
            
            var col1 = new DataGridViewColumn
            {
                HeaderText = "Словоформа",
                Name = "word",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var col2 = new DataGridViewColumn
            {
                HeaderText = "Повторений",
                Name = "repeats",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 50,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var col3 = new DataGridViewColumn
            {
                HeaderText = "Ранг",
                Name = "rank",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 50,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var col4 = new DataGridViewColumn
            {
                HeaderText = "Частота",
                Name = "freq",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 50,
                CellTemplate = new DataGridViewTextBoxCell()
            };
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;

            var words = new Dictionary<string, int>();
            var ranks = new List<int>();
            var numRanks = new SortedDictionary<int, int>();
            var ofd = new OpenFileDialog();
            var numWords = 0;
            ofd.Filter = "Text files(*.txt)|*.txt";
            stop_l("D:\\Сессия\\Основы ERP-систем\\texts\\text!.txt");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                button2.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;

                double ZipfC1 = 0;
                double ZipfC2 = 0;

                // ----------- //

                await Task.Run(() =>
                {   var sr = new StreamReader(ofd.FileName);
                    while (!sr.EndOfStream)
                    {
                        var s = sr.ReadLine();
                        var w = s.Split();
                        
                        foreach (var str in w)
                        {
                            var tmp = str.Trim('\'', '\"', '.', ',', ';', ':',
                                '?', '!', '-', '_', '-', '+', '=', '/', '*', '–',
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
                        delegate (KeyValuePair<string, int> pair1,
                        KeyValuePair<string, int> pair2)
                        {
                            return pair1.Value.CompareTo(pair2.Value);
                        });
                    wordsList.Reverse();
                    

                    var sw = new StreamWriter(ofd.FileName + "_keywords.log", false, Encoding.UTF8);
                    var _beg = ranks[(int)(0 * (double)ranks.Count)];
                    var _end = ranks[(int)(1 * (double)ranks.Count) - 1];
                    
                    if (checkBox1.Checked)
                    {
                        sw.WriteLine("Количество слов:" + words.Count.ToString());
                    }

                    var lastrang = 0;
                    var lastRep = -122;

                    dataGridView1.Rows.Clear();
                    

                    foreach (var k in wordsList)
                    {
                        if ((k.Value <= _beg) && (k.Value >= _end) && (!wordsq.Contains(k.Key)))
                        {
                            if (checkBox1.Checked && lastrang < 2000)
                            {
                                var rank = k.Value == lastRep ? lastrang : ++lastrang;
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
                    

                    var DataSer1 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
                        Color = Color.Green
                    };
                    chart1.Series.Clear();
                    var DataSer2 = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
                        Color = Color.Green
                    };
                    chart2.Series.Clear();
                    
                    for (var i = 0; i <= ranks.Count - 1; i++)
                    {
                        ZipfC1 += (ranks[i] * (double)(i + 1) / numWords);
                        DataSer1.Points.AddXY(i + 1, (double)ranks[i] / numWords);
                    }
                    

                    foreach (var kvp in numRanks)
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


                    GraphHelper.DataSer1 = DataSer1;
                    GraphHelper.GridRows = dataGridView1.Rows;
                    GraphHelper.DataSer2 = DataSer2;
                    GraphHelper.ZipfC1 = ZipfC1.ToString("f4");
                    GraphHelper.ZipfC2 = ZipfC2.ToString("f4");
                    
                });
                label1.Visible = true;

                button2.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = true;
                
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
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    chart1.Visible = true;
                    chart2.Visible = false;
                    dataGridView1.Visible = false;
                    break;
                case 1:
                    chart1.Visible = false;
                    chart2.Visible = true;
                    dataGridView1.Visible = false;
                    break;
                default:
                    chart1.Visible = false;
                    chart2.Visible = false;
                    dataGridView1.Visible = true;
                    break;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            new Graph1().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new GridForm().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Graph2().ShowDialog();
        }
        
        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
        
    }
}
