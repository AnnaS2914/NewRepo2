using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите натуральное число: ");
            int number = int.Parse(Console.ReadLine());

            if (number <= 1)
            {
                Console.WriteLine("Число должно быть больше 1");
                return;
            }

            int largestPrimeDivisor = FindLargestPrimeDivisor(number);
            Console.WriteLine($"Наибольший простой делитель: {largestPrimeDivisor}");
        }

        static int FindLargestPrimeDivisor(int n)
        {
            int largestPrime = 1;
            int temp = n;
            if (temp % 2 == 0)
            {
                largestPrime = 2;
                while (temp % 2 == 0)
                {
                    temp /= 2;
                }
            }
            for (int i = 3; i * i <= temp; i += 2)
            {
                if (temp % i == 0)
                {
                    largestPrime = i;
                    while (temp % i == 0)
                    {
                        temp /= i;
                    }
                }
            }
            if (temp > 1)
            {
                largestPrime = temp;
            }
            return largestPrime;
        }
    }
}
