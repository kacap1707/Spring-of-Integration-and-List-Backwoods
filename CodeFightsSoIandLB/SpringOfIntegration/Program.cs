﻿using System;
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

            Console.WriteLine(pairOfShoes(new []
            {
                new []{0,21},
                new []{1,23},
                new []{1,21},
                new []{0,23}
            }));
            Console.ReadKey();
        }
        public static int arrayConversion(int[] inputArray)
        {
            var listPlus = new List<int>();
            var listProduct = inputArray.ToList();

            while (true)
            {
                if(listProduct.Count==1) return listProduct[0];
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
            var list = new List<int> {-1};
            int j;
            for (int i = 1; i < items.Length; i++)
            {
                j = i;
                while (j>0)
                {
                    j--;
                    if (items[j] >= items[i]) continue;
                    list.Add(items[j]);
                    break;
                }
                if(list.Count<i+1) list.Add(-1);
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

        }
    }
}