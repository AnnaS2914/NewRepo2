using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число: ");
            int number = int.Parse(Console.ReadLine());

            int temp = number;
            int minDigit = 9;
            int maxDigit = 0;

            if (temp < 10)
            {
                minDigit = temp;
                maxDigit = temp;
            }
            else
            {
                while (temp > 0)
                {
                    int digit = temp % 10;

                    if (digit < minDigit)
                        minDigit = digit;

                    if (digit > maxDigit)
                        maxDigit = digit;

                    temp /= 10;
                }
            }
            int sum = minDigit + maxDigit;

            Console.WriteLine($"Число: {number}");
            Console.WriteLine($"Минимальная цифра: {minDigit}");
            Console.WriteLine($"Максимальная цифра: {maxDigit}");
            Console.WriteLine($"Сумма минимальной и максимальной цифр: {sum}");
        }
    }
}
