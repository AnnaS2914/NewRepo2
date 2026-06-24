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
            {'А', "4"}, {'a',"4"},
            {'B', "8"}, {'b',"8"},
            {'C', "("}, {'c',"("},
            {'D', "|)"}, {'d',"|)"},
            {'E', "3"}, {'e', "3"},
            {'F', "|="},{'f', "|="},
            {'G', "6"},{'g', "6"},
            {'H', "|-|"},{'h', "|-|"},
            {'I', "!"},{'i', "!"},
            {'J', ")*"},{'j', ")*"},
            {'K', "|<"},{'k', "|<"},
            {'L', "1"},{'l', "1"},
            {'M', @"|\/|"},{'m', @"|\/|"},
            {'N', @"|\|"},{'n', @"|\|"},
            {'O', "0"},{'o', "0"},
            {'P', "|>"},{'p', "|>"},
            {'Q', "9"},{'q', "9"},
            {'R', "|2"},{'r', "|2"},
            {'S', "5"},{'s', "5"},
            {'T', "7"},{'t', "7"},
            {'U', "|_|"},{'u', "|_|"},
            {'V', @"\/"},{'v', @"\/"},
            {'W', @"\/\/"},{'w', @"\/\/"},
            {'X', "><"},{'x', "><"},
            {'Y', "'/"},{'y', "'/"},
            {'Z', "2"}, {'z', "2"},
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

