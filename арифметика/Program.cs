using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace арифметика
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 4-хзначное число:");

            var n = int.Parse(Console.ReadLine());

            var a = n / 1000;           
            var cd = n % 100;         
            var b = (n / 100) % 10;   

            var result = a * 100 + cd;
            result = result * 10 + b;

            Console.WriteLine(result);
        }
    }
}
