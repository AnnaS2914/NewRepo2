using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = Calculate(2, 3) + Calculate(3, 5) + Calculate(4, 3);
            Console.WriteLine(x);
        }
        static double Calculate(double a, double b) =>
         Math.Sin((Math.Pow(a, a) + 1) / Math.Pow(b, b) + 1);
    }
}