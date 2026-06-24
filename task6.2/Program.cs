using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "прогулка";

            int posP = word.IndexOf('п');
            int posG = word.IndexOf('г');
            int posO = word.IndexOf('о');
            int posR = word.IndexOf('р');
            int posK = word.IndexOf('к');
            int posA = word.IndexOf('а');

            string p = word.Substring(posP, 1);
            string g = word.Substring(posG, 1);
            string o = word.Substring(posO, 1);
            string r = word.Substring(posR, 1);
            string k = word.Substring(posK, 1);
            string a = word.Substring(posA, 1);

            string gorka = g + o + r + k + a;
            string porog = p + o + r + o + g;

            Console.WriteLine($"Исходное слово: {word}");
            Console.WriteLine($"Полученное слово 'горка': {gorka}");
            Console.WriteLine($"Полученное слово 'порог': {porog}");
        }
    }
}
