using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное целое число n (n ≤ 18446774073709551615):");
            string input = Console.ReadLine();
            if (!ulong.TryParse(input, out ulong number) || number == 0)
            {
                Console.WriteLine("Некорректное значение");
                return;
            }

            int length = input.Length;
            int[] digits = new int[length];
            for (int i = 0; i < length; i++)
            {
                digits[i] = input[length - 1 - i] - '0';
            }

            PrintIntArray(digits);

            Console.WriteLine("Введите значение k:");
            if (!int.TryParse(Console.ReadLine(), out int k))
            {
                Console.WriteLine("Некорректное значение k");
                return;
            }
            AddModulo10ToArray(digits, k);
            PrintIntArray(digits);

            int sumMod10 = SumModulo10(digits);
            Console.WriteLine($"Сумма элементов массива по модулю 10: {sumMod10}");

            int[] swapped = SwapNeighbours(digits);
            PrintIntArray(swapped);
        }

        static void PrintIntArray(int[] array)
        {
            
            Console.WriteLine(string.Join("; ", array));
        }

        static void AddModulo10ToArray(int[] array, int k)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (array[i] + k) % 10;
            }
        }

        static int SumModulo10(int[] array)
        {
            int sum = 0;
            foreach (int item in array)
                sum = (sum + item)%10;
            return sum % 10;
        }

        static int[] SwapNeighbours(int[] array)
        {
            int length = array.Length;
            int[] result = new int[length];
            Array.Copy(array, result, length);

            for (int i = 0; i < length - 1; i += 2)
            {
                int temp = result[i];
                result[i] = result[i + 1];
                result[i + 1] = temp;
            }
            return result;
        }
    }
}

