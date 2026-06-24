using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 0, n = 0;

            while (true)
            {
                Console.WriteLine("Введите через пробел два натуральных числа n и m от 5 до 20");
                Console.WriteLine("(Enter - отказ от ввода)");
                var input = Console.ReadLine();

                if (input == string.Empty)
                    return;

                var strings = input.Split();

                if (strings.Length == 2 && int.TryParse(strings[0], out m) &&
                    int.TryParse(strings[1], out n) && 5 <= m && m <= 20 &&
                    5 <= n && n <= 20)
                    break;
                else
                {
                    Console.WriteLine("Ошибка ввода");
                    continue;
                }
            }

            var matrix = new int[m, n];

            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(0, 100);

            Console.WriteLine();

            PrintTable(matrix);
            Console.WriteLine();
            // Запрос a и b для интервала
            int a = ReadNumber("Введите число a (интервал): ");
            int b = ReadNumber("Введите число b (интервал): ");

            var intervalCheck = CheckElementsInInterval(matrix, a, b);
            if (intervalCheck.isInInterval)
                Console.WriteLine($"Все элементы массива находятся в интервале ({a}, {b})");
            else
                Console.WriteLine($"Элемент, нарушающий условие, находится на позиции [{intervalCheck.row}, {intervalCheck.col}] со значением {matrix[intervalCheck.row, intervalCheck.col]}");

            Console.WriteLine();

            var maxInColumns = FindMaxInColumns(matrix);
            Console.WriteLine("Максимальные элементы по столбцам:");
            for (int i = 0; i < maxInColumns.Length; i++)
            {
                Console.WriteLine($"Столбец {i}: {maxInColumns[i]}");
            }
        }

        static int ReadNumber(string prompt)
        {
            int val;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out val))
                    return val;
                Console.WriteLine("Ошибка ввода. Повторите.");
            }
        }

        static void PrintTable(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write($"{arr[i, j],4}");
                Console.WriteLine();
            }
        }

        static (bool isInInterval, int row, int col) CheckElementsInInterval(int[,] arr, int a, int b)
        {
            if (a > b)
            {
                var temp = a;
                a = b;
                b = temp;
            }

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (!(arr[i, j] > a && arr[i, j] < b))
                        return (false, i, j);

            return (true, -1, -1);
        }

        static int[] FindMaxInColumns(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int[] maxValues = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                int max = arr[0, j];
                for (int i = 1; i < rows; i++)
                    if (arr[i, j] > max)
                        max = arr[i, j];
                maxValues[j] = max;
            }
            return maxValues;
        }
    }
}

