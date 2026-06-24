using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите абциссу точки");
            var x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите ординату точки");
            var y = double.Parse(Console.ReadLine());
            if (IsInArea(x, y))
                Console.WriteLine("точка лежит в указанной области");
            else
                Console.WriteLine("точка не лежит в указанной области");
        }
        static bool IsInArea(double x, double y) =>
            y >= -2 && y <= 1.5;
    }
}
