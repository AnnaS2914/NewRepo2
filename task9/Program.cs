using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение аргумента");

            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x:F2}) = {F(x):F2}");
        }

        static double F(double x)
        {
            if (x < 2)
                return x-2;
            else if (x >= 2&& x<=3)
                return 0;
            else
                return 3-x;
        }
    }
}
