using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число n:");
            int n = int.Parse(Console.ReadLine());

            double sum = 1;

            for (int i = 1; i <= n; i++)
            {
                double term = 1.0 / i;

                if (i % 2 == 1)  
                    sum += term;
                else            
                    sum -= term;
            }
            Console.WriteLine($"Сумма ряда: {sum:F6}");
        }
    }
}
 