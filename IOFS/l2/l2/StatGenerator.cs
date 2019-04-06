using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace l2
{
    class StatGenerator
    {
        string filename;
        public int numWords;
        public StatGenerator(string pathname)
        {
            filename = pathname;
        }

        public Dictionary<string,int> GetStatistics()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            numWords = 0;
            StreamReader sr = new StreamReader(filename);
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
            return words;
        }
    }
}
