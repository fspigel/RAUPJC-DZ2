﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RAUPJC_DZ2_zad6
{
    class Program
    {
        private static object _lock = new object();

        static void Main(string[] args)
        { 
            
            List<int> results = new List<int>();
            Parallel.For(0, 100, (i) =>
            {
                Thread.Sleep(1); 
                lock (_lock)
                {
                    results.Add(i * i);
                }
            }) ;
            Console.WriteLine("Bag length should be 100. Length is {0}", results.Count);
            Console.ReadLine();
        }
    }
}
