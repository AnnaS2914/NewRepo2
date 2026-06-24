using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел");
            var n = int.Parse(Console.ReadLine());
            double[] a = new double[n + 1];

            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Введите a[{i}]: ");
                a[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Результат:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{a[i]}{a[i + 1]}");
                if (i < n - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}
