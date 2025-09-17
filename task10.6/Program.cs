using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число m: ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Введите натуральное число n: ");
            int n = int.Parse(Console.ReadLine());

            if (m <= 0 || n <= 0)
            {
                Console.WriteLine("Числа должны быть натуральными (больше 0)");
                return;
            }

            long totalSum = 0;

            for (int i = 1; i <= m; i++)
            {
                long powerResult = 1;

                for (int j = 1; j <= n; j++)
                {
                    powerResult *= i;
                }

                totalSum += powerResult;
            }

            Console.WriteLine($"Сумма 1^{n} + 2^{n} + ... + {m}^{n} = {totalSum}");
        }
    }
}
