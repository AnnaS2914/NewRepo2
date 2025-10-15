using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первый член прогрессии : ");
            var a = double.Parse(Console.ReadLine());

            Console.Write("Введите знаменатель прогрессии : ");
            var b = double.Parse(Console.ReadLine());

            Console.Write("Введите номер члена прогрессии : ");
            var c = double.Parse(Console.ReadLine());
            
            var G = a *Math.Pow(b,c-1);

            Console.WriteLine("n-й член прогрессии: " + G);
        }
    }
}
