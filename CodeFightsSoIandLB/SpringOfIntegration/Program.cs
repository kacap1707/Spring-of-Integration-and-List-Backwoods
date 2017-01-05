using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringOfIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var VARIABLE in arrayPreviousLess(new []{ 3, 5, 2, 4, 5 }))
            //    Console.WriteLine(VARIABLE);

            Console.WriteLine(beautifulText("aa aa aaaaa aaaaa aaaaa", 6, 11));
            Console.ReadKey();
        }
        public static int arrayConversion(int[] inputArray)
        {
            var listPlus = new List<int>();
            var listProduct = inputArray.ToList();

            while (true)
            {
                if (listProduct.Count == 1) return listProduct[0];
                for (int i = 0; i < listProduct.Count; i++)
                    if (i % 2 == 0) listPlus.Add(listProduct[i] + listProduct[i + 1]);

                listProduct.Clear();

                if (listPlus.Count == 1) return listPlus[0];
                for (int i = 0; i < listPlus.Count; i++)
                    if (i % 2 == 0) listProduct.Add(listPlus[i] * listPlus[i + 1]);

                listPlus.Clear();
            }

            //int curCount = inputArray.Length / 2;
            //bool odd = true;
            //while (curCount >= 1)
            //{
            //    //Odd Iteration -- Sum Pairs
            //    for (int i = 0; i < curCount; i++)
            //    {
            //        if (odd == true)inputArray[i] = inputArray[i * 2] + inputArray[(i * 2) + 1];
            //        else inputArray[i] = inputArray[i * 2] * inputArray[(i * 2) + 1];
            //    }
            //    odd = !odd;
            //    curCount = curCount / 2;
            //}
            //return inputArray[0];
        }
        public static int[] arrayPreviousLess(int[] items)
        {
            var list = new List<int> { -1 };
            int j;
            for (int i = 1; i < items.Length; i++)
            {
                j = i;
                while (j > 0)
                {
                    j--;
                    if (items[j] >= items[i]) continue;
                    list.Add(items[j]);
                    break;
                }
                if (list.Count < i + 1) list.Add(-1);
            }
            return list.ToArray();

            //return Enumerable.Range(0, items.Length).Select(i => items.Take(i).Reverse().FirstOrDefault(p => p < items[i])).Select(n => n > 0 ? n : -1).ToArray();
        }
        public static bool pairOfShoes(int[][] shoes)
        {
            var size = shoes.Select(x => x[1]).Distinct().ToList();
            return size.Select(t => shoes.Where(x => x[1] == t).Select(y => y[0])).All(r => r.Count(x => x == 0) == r.Count(y => y == 1));

            //return shoes.GroupBy(s1 => s1[1])
            //    .Select(g => new { d = g.Count(a => a[0] == 1), i = g.Count(a => a[0] == 0) })
            //    .All(t => t.d == t.i);

            //return shoes.GroupBy(s => s[1]).All(g => g.Count(s => s[0] == 0) == g.Count(s => s[0] == 1));
        }
        public static int combs(string comb1, string comb2)
        {
            var l1 = comb1.Split('*').ToList();
            var l2 = comb2.Split('*').ToList();
            if (l1.Any(z => z.Length >= comb2.Length) || l2.Any(z => z.Length >= comb1.Length)) return Math.Max(comb1.Length, comb2.Length);
            var len1 = l1.Select(x => x.Length).ToList();
            var len2 = l2.Select(x => x.Length).ToList();
            len1.Sort();
            len2.Sort();

            var d1 = len1.Max();
            var d2 = len2.Max();
            for (int i = Math.Max(d1, d2) - 1; i > 0; i--)
                if (len1.Contains(i) && len2.Contains(i)) return Math.Max(comb1.Length, comb2.Length) + Math.Min(comb1.Length, comb2.Length) - i - 1;

            return Math.Max(comb1.Length, comb2.Length) + Math.Min(comb1.Length, comb2.Length) - Math.Min(d1, d2) - 1;
        }       //TODO hidden tests doesn't pass
        public static int stringsCrossover(string[] inputArray, string result)
        {
            var pairs = 0;
            for (var i = 0; i < inputArray.Length - 1; i++)
            {
                for (var j = i + 1; j < inputArray.Length; j++)
                    if (!inputArray[i].Where((t, index) => result[index] != t && result[index] != inputArray[j][index]).Any()) pairs++;
            }
            return pairs;
        }
        public static int cyclicString(string s)
        {
            var repeatingPhrase = new List<char> { s[0] };
            var n = s.Length / repeatingPhrase.Count + 1;
            repeatingPhrase.RemoveAt(0);
            var list = new List<char>();
            foreach (var character in s)
            {
                repeatingPhrase.Add(character);
                list.AddRange(Enumerable.Repeat(repeatingPhrase, n).SelectMany(x => x));
                if (new string(list.ToArray()).Contains(s)) return repeatingPhrase.Count;
                list.Clear();
            }
            return -1;
        }
        public static bool beautifulText(string inputString, int l, int r)
        {
            var initialL = l;
            while (r + 1 >= l)
            {
                var list1 = inputString.Where((x, i) => (i + 1) % l == 0 && i != 0).ToList();
                var textWidth = l - 1;
                var textFits = textWidth >= initialL && textWidth <= r;
                if (list1.All(x => x == ' ') && (inputString.Length - list1.Count) % (l - 1) == 0 && textFits) return true;
                ++l;
            }
            return false;
        }
    }
}
