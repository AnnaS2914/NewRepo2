using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace расчеты19
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Расчеты. Вариант 19.");
            Console.Write("Введите первый член прогрессии (x): ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите знаменатель прогрессии (y): ");
            double y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите номер члена прогрессии (n): ");
            int n= Convert.ToInt32(Console.ReadLine());

            double xn = x * Math.Pow(y, n - 1);

            Console.WriteLine($"{n}-й член прогрессии: {xn}");
            Console.ReadLine();
        }
    }
}
