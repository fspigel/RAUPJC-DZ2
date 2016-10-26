using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RAUPJC_DZ2_zad7
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static int GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy().Result;
        }

        private async static Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            Task<int> t1 = IKnowWhoKnowsThis(10);
            Task<int> t2 = IKnowWhoKnowsThis(5);
            await Task.WhenAll(t1, t2);
            return t1.Result + t2.Result;
        }

        private static Task<int> IKnowWhoKnowsThis(int n)
        {
            return FactorialDigitSum(n);
        }
        private async static Task<int> FactorialDigitSum(int number)
        {
            Task<int> task = Task.Run(() => GetDigitSum(GetFactorial(number)));
            await task;
            return task.Result;
        }

        private static int GetFactorial(int number)
        {
            int f = 1;
            for (int i = 1; i <= number; i++)
            {
                f *= i;
            }
            return f;
        }

        private static int GetDigitSum(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            Thread.Sleep(3000);
            return sum;
        }
    }
}
