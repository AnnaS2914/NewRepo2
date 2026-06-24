 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белого слона:");
            string whiteElephantPosition = Console.ReadLine();

            Console.WriteLine("Введите позицию черного коня:");
            string blackKnightPosition = Console.ReadLine();

            if (whiteElephantPosition == blackKnightPosition)
            {
                Console.WriteLine("Фигуры не могут стоять на одной клетке");
                return;
            }

            int whiteVert, whiteHor;
            int blackVert, blackHor;

            DecodePosition(whiteElephantPosition, out whiteVert, out whiteHor);
            DecodePosition(blackKnightPosition, out blackVert, out blackHor);

            if (!IsValidPosition(whiteVert, whiteHor) || !IsValidPosition(blackVert, blackHor))
            {
                Console.WriteLine("Введены некорректные позиции фигур");
                return;
            }

            bool whiteUnderStrike = IsUnderStrikeByKnight(whiteVert, whiteHor, blackVert, blackHor);
            bool blackUnderStrike = IsUnderStrikeByElephant(blackVert, blackHor, whiteVert, whiteHor);

            if (whiteUnderStrike || blackUnderStrike)
                Console.WriteLine("Одна из фигур бьет другую");
            else
                Console.WriteLine("Фигуры друг друга не бьют");
        }

        static void DecodePosition(string position, out int vert, out int hor)
        {
            vert = position[0] - 'a' + 1; 
            hor = int.Parse(position[1].ToString());
        }
        static bool IsValidPosition(int vert, int hor)
        {
            return vert >= 1 && vert <= 8 && hor >= 1 && hor <= 8;
        }

        static bool IsUnderStrikeByKnight(int pVert, int pHor, int kVert, int kHor)
        {
            int dVert = Math.Abs(pVert - kVert);
            int dHor = Math.Abs(pHor - kHor);

            return (dVert == 2 && dHor == 1) || (dVert == 1 && dHor == 2);
        }

        static bool IsUnderStrikeByElephant(int pVert, int pHor, int eVert, int eHor)
        {
            return Math.Abs(pVert - eVert) == Math.Abs(pHor - eHor) && (pVert != eVert);
        }
    }
}
