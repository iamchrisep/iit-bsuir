using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace l7_
{
    public class ReviewManager
    {
        public ReviewManager(int percent)
        {
            _percent = percent;
        }

        private int _percent;
        private string[] _stopWords;
        public List<TextWords> Words { get; set; }
        public List<Sentence> Sentences { get; set; }

        public string GetReview(string sourceText)
        {
            var words = SplitWords(sourceText).ToList();
            Words = new List<TextWords>();
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
                        var newWord = new TextWords { Count = 1, Name = words[i] };
                        Words.Add(newWord);
                    }
                    else
                    {
                        selWord.Count++;
                    }
                }
            }


            Words = Words.OrderByDescending(w => w.Count).ToList();
            var propasal = SplitSentance(sourceText);
            Sentences = new List<Sentence>();
            for (int i = 0; i < propasal.Length; i++)
            {
                var sentWords = SplitWords(propasal[i]);
                var wordCount = 0;
                foreach (var sentWord in sentWords)
                {
                    var contains = Words.Any(w => w.Name == sentWord);
                    var word = (!contains) ? null : Words.Where(w => w.Name == sentWord).First();
                    wordCount += (word == null) ? 0 : word.Count;
                }
                Sentences.Add(new Sentence { Count = wordCount, Name = propasal[i] });
            }
            Sentences = Sentences.OrderByDescending(s => s.Count).ToList();
            if (!(_percent > 0 && _percent < 100))
            {
                _percent = 100;
            }
            var count = Sentences.Count * _percent / 100;
            var res = "";
            for (int i = 0; i < count; i++)
            {
                res += Sentences[i].Name;
            }

            return res;
        }

        public void LoadStopWords(string text)
        {
            _stopWords = SplitWords(text);
        }

        private string[] SplitWords(string s)
        {
            return Regex.Split(s, @"[^а-яА-Я]+", RegexOptions.IgnoreCase);
        }

        private string[] SplitSentance(string s)
        {
            return Regex.Split(s, @"(?<=[.?!])\s+");
        }
    }
}
