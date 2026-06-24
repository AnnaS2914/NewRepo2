using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите действительное число");

            var x = double.Parse(Console.ReadLine());
            var y = F(x);

            Console.WriteLine("y = " + y);

        }
        static double F(double x) => (-Math.Pow(x, 3) + (1 / (x * x + 1))) / (1 + (5 / (x * x + x + 1)));
    }
}
