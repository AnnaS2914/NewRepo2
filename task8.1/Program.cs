using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число n");
            var n = int.Parse(Console.ReadLine());
            if (IfLogicalExpressionTrue(n))
                Console.WriteLine("n не кратно ни пяти, ни восьми");
            else
                Console.WriteLine("Либо кратно 5 или 8");
        }
        static bool IfLogicalExpressionTrue(int n) =>
            (n % 5 != 0) && (n % 8 != 0);
    }
}
