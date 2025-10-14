using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите текст на ангийском языке:");
            string input = Console.ReadLine();

            string result = ConvertToCsAlphabet(input);

            Console.WriteLine("\nПеревод на алфавит Leet:");
            Console.WriteLine(result);
        }

        static string ConvertToCsAlphabet(string russianText)
        {
            if (string.IsNullOrEmpty(russianText))
                return string.Empty;

            var translationTable = new Dictionary<char, string>
        {
            {'А', "4"},
            {'B', "8"},
            {'C', "("},
            {'D', "|)"},
            {'E', "3"},
            {'F', "|="},
            {'G', "6"},
            {'H', "|-|"},
            {'I', "!"},
            {'J', ")*"},
            {'K', "|<"},
            {'L', "1"},
            {'M', @"|\/|"},
            {'N', @"|\|"},
            {'O', "0"},
            {'P', "|>"},
            {'Q', "9"},
            {'R', "|2"},
            {'S', "5"},
            {'T', "7"},
            {'U', "|_|"},
            {'V', @"\/"},
            {'W', @"\/\/"},
            {'X', "><"},
            {'Y', "'/"},
            {'Z', "2"},
        };

            StringBuilder result = new StringBuilder();

            foreach (char c in russianText)
            {
                if (translationTable.ContainsKey(c))
                {
                    result.Append(translationTable[c]);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}

