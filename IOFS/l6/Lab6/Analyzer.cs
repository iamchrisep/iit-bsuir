using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab6
{
    public class Analyzer
    {
        StreamWriter sw;
        public Analyzer()
        {
            sw = new StreamWriter(@"E:\WorkMaterials\ИОФС\l7\Lab6\bin\Debug\dump.txt");
            _examples = new List<Example>();
        }
        private string[] _stopWords { get; set; }
        private List<Example> _examples { get; set; } 
        public void AddExample(string sourceText, string topic)
        {
            var words = SplitWords(sourceText).ToList();
            var Words = new List<TextWord>();
            for (int i = 0; i < words.Count; i++)
            {
                if (_stopWords.Contains(words[i]))
                {
                    words.RemoveAt(i);
                    i--;
                }
                else
                {
                    var selWord = Words.Find(t => t.Name == words[i]);
                    if (selWord == null)
                    {
                        var newWord = new TextWord { Count = 1, Name = words[i] };
                        Words.Add(newWord);
                    }
                    else
                    {
                        selWord.Count++;
                    }
                }
            }


            Words = Words.OrderByDescending(w => w.Count).ToList();
            if(Words.Count > 3)
            {
                sw.WriteLine("Topic: " + topic + ", words:" + Words[0].Name + ',' + Words[1].Name + ',' + Words[2].Name + ';');
                _examples.Add(new Example{
                                            Topic = topic,
                                            FirstKeyWord = Words[0].Name,
                                            SecondKeyWord = Words[1].Name,
                                            ThirdKeyWord = Words[2].Name
                                            });
            }
        }

        public string Analyze(string text)
        {
            var keyWords = new List<string>();
            foreach (var example in _examples)
            {
                keyWords.Add(example.FirstKeyWord);
                keyWords.Add(example.SecondKeyWord);
                keyWords.Add(example.ThirdKeyWord);
            }

            var attributes = new List<List<bool>>();
            foreach (var example in _examples)
            {
                var attr = new List<bool>();
                foreach (var keyWord in keyWords)
                {
                    if(
                        (keyWord == example.FirstKeyWord)
                        ||(keyWord == example.SecondKeyWord)
                        ||(keyWord == example.ThirdKeyWord))
                    {
                        attr.Add(true);
                    }
                    else
                    {
                        attr.Add(false);
                    }
                }
                attr.Add(true);
                attributes.Add(attr);
            }


            bool needCorrecting = true;
            var i = attributes.Count;
            var j = attributes[0].Count;
            var weights = new int[i,j];
            for (int k = 0; k < i; k++)
            {
                for (int l = 0; l < j; l++)
                {
                    weights[k, l] = 0;
                }
            }

            while (needCorrecting)
            {
                needCorrecting = false;
                for (int attCounter = 0; attCounter < attributes.Count; attCounter++)
                {
                    var rules = new int[i];
                    var correct = false;
                    for (int k = 0; k < i; k++)
                    {
                        var tmp = 0;
                        for (int l = 0; l < j; l++)
                        {
                            if(attributes[attCounter][l])
                            {
                                tmp += weights[k, l];
                            }
                        }
                        rules[k] = tmp;
                    }

                    for(var t = 0; t < i; t++)
                    {
                        if(rules[t] >= rules[attCounter])
                        {
                            if(t != attCounter)
                            {
                                correct = true;
                                needCorrecting = true;
                                break;
                            }
                        }
                    }

                    if(correct)
                    {
                        for (int t = 0; t < attCounter; t++)
                        {
                            if (rules[t] >= rules[attCounter])
                            {
                                if (t != attCounter)
                                {
                                    for (int l = 0; l < j; l++)
                                    {
                                        if(attributes[attCounter][l])
                                        {
                                            weights[t, l] -= 1;
                                        }
                                    }
                                }
                            }
                        }

                        for (int l = 0; l < j; l++)
                        {
                            if (attributes[attCounter][l])
                            {
                                weights[attCounter, l] += 1;
                            }
                        }
                    }
                }
            }


            var words = SplitWords(text).ToList();
            var Words = new List<TextWord>();
            for (int l = 0; l < words.Count; l++)
            {
                if (_stopWords.Contains(words[l]))
                {
                    words.RemoveAt(l);
                    l--;
                }
                else
                {
                    var selWord = Words.Find(t => t.Name == words[l]);
                    if (selWord == null)
                    {
                        var newWord = new TextWord { Count = 1, Name = words[l] };
                        Words.Add(newWord);
                    }
                    else
                    {
                        selWord.Count++;
                    }
                }
            }


            Words = Words.OrderByDescending(w => w.Count).ToList();
            sw.WriteLine("Words for check:" + Words[0].Name + ',' + Words[1].Name + ',' + Words[2].Name + ';');
            var ex = new Example() {FirstKeyWord = Words[0].Name, SecondKeyWord = Words[1].Name, ThirdKeyWord = Words[2].Name};
            var attribute = new List<bool>();
            foreach (var keyWord in keyWords)
            {
                if (
                    (keyWord == ex.FirstKeyWord)
                    || (keyWord == ex.SecondKeyWord)
                    || (keyWord == ex.ThirdKeyWord))
                {
                    attribute.Add(true);
                }
                else
                {
                    attribute.Add(false);
                }
            }
            attribute.Add(true);

            var r = new int[i];
            var max = 0;
            for (int k = 0; k < i; k++)
            {
                var tmp = 0;
                for (int l = 0; l < j; l++)
                {
                    if (attribute[l])
                    {
                        tmp += weights[k, l];
                    }
                }
                r[k] = tmp;
                if(r[k] > r[max])
                {
                    max = k;
                }
            }
            sw.WriteLine("Topic:"+_examples[max].Topic);
            sw.Flush();
            return _examples[max].Topic;
        }

        public void LoadStopWords(string text)
        {
            _stopWords = SplitWords(text);
        }

        private string[] SplitWords(string s)
        {
            return Regex.Split(s, @"[^а-яА-Я]+", RegexOptions.IgnoreCase);
        }
    }
}
