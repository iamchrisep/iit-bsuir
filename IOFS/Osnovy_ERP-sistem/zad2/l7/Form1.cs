using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l7
{
    public partial class Form1 : Form
    {
        private string _currPath = "D:\\Renata\\texts";
        private string _curFileName = "";
        private List<string> wordsq = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
            tbDirPath.Text = _currPath;
        }

        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
                _currPath = folderDlg.SelectedPath;
                tbDirPath.Text = _currPath;
            }
        }
        
        private void btnGetTerms_Click(object sender, EventArgs e)
        {
            var words = new Dictionary<string, int>();
            var ranks = new List<int>();
            var numRanks = new SortedDictionary<int, int>();
            var numWords = 0;

            var ofd = new OpenFileDialog
            {
                InitialDirectory = _currPath,
                Filter = "Text files(*.txt)|*.txt"
            };
            
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            tbTerms.Clear();

            GetStopList("D:\\Renata\\texts\\text!.txt");

            _curFileName = ofd.FileName;

            var sr = new StreamReader(_curFileName);
            while (!sr.EndOfStream)
            {
                foreach (var str in sr.ReadLine().Split())
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

            //var sw = new StreamWriter(_curFileName + "_keywords.log", false, Encoding.UTF8);
            var _beg = ranks[(int) (0.3*(double) ranks.Count)];
            var _end = ranks[(int) (0.5*(double) ranks.Count)]; //0,5
            //var _beg = ranks[(int)(0 * (double)ranks.Count)];
            //var _end = ranks[(int)(1 * (double)ranks.Count) - 1];
            foreach (var k in wordsList)
            {
                if ((k.Value <= _beg) && (k.Value >= _end) && (k.Key.Length > 2) && (!wordsq.Contains(k.Key)))
                {
                    tbTerms.Text += k.Key + " ";
                }
            }
            //sw.Close();            
        }

        public void GetStopList(string pFilePath)
        {
            var sr = new StreamReader(pFilePath);
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

        private void btnGetEssay_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_curFileName))
            {
                return;
            }
            var vSize = 0;
            try
            {
                vSize = Convert.ToInt32(tbSize.Text.Trim('%'));
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неверное значение");
                return;
            }

            tbEssay.Clear();

            var vResSentMas = new List<string>(); //подходящие предложения 
            var vEssayText = ""; //реферат
            //ключевые слова
            var vTerms = tbTerms.Text.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();               
            var vSeparatMas = new string[] {".", ". "};
            var bFull = false; //флаг, позволяющий понять, достигнут ли необходимый размер реферата

            var vAllCount = 0;
            //считаем размер
            using (var stream = File.OpenRead(_curFileName))
            {
                vAllCount = (int) stream.Length; //100%                                                
            }
            var sr = new StreamReader(_curFileName);

            while (!sr.EndOfStream && !bFull)
            {
                //для каждого предложения
                foreach (var line in sr.ReadLine().Split(vSeparatMas, StringSplitOptions.RemoveEmptyEntries))
                {
                    //что сейчас есть (для определения текущего размера)
                    vEssayText = "";
                    foreach (var str in vResSentMas)
                    {
                        vEssayText += str + ". ";
                    }
                    var vCurrCount = vEssayText.Length; //текущий размер 
                    var vNeedCount = (vSize*vAllCount)/100; //необходимый размер
                    //проверка, а не достигли ли мы нужного размера
                    if (vCurrCount < vNeedCount)
                    {
                        foreach (var term in vTerms)
                        {
                            if (line.Contains(term))
                            {
                                vResSentMas.Add(line);
                                break;
                            }
                        }
                    }
                    else
                    {
                        bFull = true; //достигли размера
                        break;
                    }
                }
            }
            tbEssay.Text = vEssayText;
        }
    }
}