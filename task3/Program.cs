using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 4-хзначное число:");

            var n = int.Parse(Console.ReadLine());

            var x = n / 1000;

            var y = n % 100;

            var result = x * 100 + y;

            Console.WriteLine("Полученное число: " + result);
        }
    }
}
