using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Sop.Collections.Generic.BTree;

namespace BTreeSample
{
    class Program
    {
        private static int n = 10;
        private static Random rand = new Random(1234);
        static void Main(string[] args)
        {
            var b2Dict = new BTreeDictionary<int, int>();
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < n; i++ )
            {
                b2Dict.Add(i, i*10);
                dict.Add(i, i*10);
            }

            var key = rand.Next(n);
            SearchB2Test(b2Dict, key);
            SearchDictTest(dict, key);
            AddB2Test(b2Dict);
            AddDictTest(dict);
            DeleteB2Test(b2Dict);
            DeleteDictTest(dict);
            Console.ReadLine();
           
        }
        #region SearchTest
        private static bool SearchB2Test(BTreeDictionary<int, int> data, int searchKey)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int value = data[searchKey];
            //Console.WriteLine("");
            sw.Stop();
            Console.WriteLine("B-Tree: Search element in {0} ms; key: {1} value: {2}", sw.Elapsed.TotalMilliseconds, searchKey, value);
            return true;
        }

        private static bool SearchDictTest(Dictionary<int, int> data, int searchKey)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int value = data[searchKey];
            sw.Stop();
            Console.WriteLine("HashTable: Search element in {0} ms; key: {1} value: {2}", sw.Elapsed.TotalMilliseconds, searchKey, value);
            return true;
        }
        #endregion

        private static bool AddB2Test(BTreeDictionary<int, int> data)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //bool found = data.Search(searchKey);
            data.Add(n+1,(n+1)*10);
            sw.Stop();
            Console.WriteLine("B-Tree: Add element in {0} ms", sw.Elapsed.TotalMilliseconds);
            return true;
        }

        private static bool AddDictTest(Dictionary<int, int> data)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //bool found = data.Search(searchKey);
            data.Add(n + 1, (n + 1) * 10);
            sw.Stop();
            Console.WriteLine("Hash-table: Add element in {0} ms", sw.Elapsed.TotalMilliseconds);
            return true;
        }

        private static bool DeleteB2Test(BTreeDictionary<int, int> data)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //bool found = data.Search(searchKey);
            data.Remove(n + 1);
            
            sw.Stop();
            Console.WriteLine("B-Tree: Delete element in {0} ms", sw.Elapsed.TotalMilliseconds);
            return true;
        }

        private static bool DeleteDictTest(Dictionary<int, int> data)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //bool found = data.Search(searchKey);
            data.Remove(n + 1);

            sw.Stop();
            Console.WriteLine("Hash-Table: Delete element in {0} ms", sw.Elapsed.TotalMilliseconds);
            return true;
        }
    }
}
