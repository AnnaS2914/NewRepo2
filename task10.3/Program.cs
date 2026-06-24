using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число > 1");
            var a = double.Parse(Console.ReadLine());

            long n = 1;
            double sum = 1.0; 
            Console.WriteLine($"n = {n}");

            while (sum < a)
            {
                n++;
                sum += 1.0 / n;

                if (sum < a)
                {
                    Console.WriteLine($"n = {n}");
                }
            }
        }
     }
  }
 
