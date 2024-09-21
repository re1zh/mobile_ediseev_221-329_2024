using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrintShapes
{
    internal class Program
    {

        static string[] GetRhomb(int height, char symbol, bool isFilled)
        {
            height = height % 2 == 0 ? height + 1 : height;

            int midHeight = height / 2;
            string[] rhomb = new string[height];

            for (int i = 0; i <= midHeight; i++)
            {
                int spacesBefore = midHeight - i;
                int spacesAfter = 2 * i - 1;

                if (isFilled)
                {
                    if (i == 0)
                    {
                        rhomb[i] = new string(' ', spacesBefore) + symbol; 
                    }
                    else
                    {
                        rhomb[i] = new string(' ', spacesBefore) + symbol + new string(symbol, spacesAfter) + symbol;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        rhomb[i] = new string(symbol, spacesBefore) + symbol + new string(symbol, spacesBefore);
                    }
                    else
                        rhomb[i] = new string(symbol, spacesBefore) + symbol + new string(' ', spacesAfter) + new string(symbol, spacesBefore) + symbol ;
                }

                rhomb[height - i - 1] = rhomb[i];
            }

            return rhomb;
        }

        static void PrintRhomb(string[] rhomb)
        {
            int height = rhomb.Length;

            for (int i = 0; i < height / 2; i++)
            {
                Console.WriteLine($"{i} {rhomb[i]}");
            }

            for (int i = height / 2; i >= 0; i--)
            {
                Console.WriteLine($"{i} {rhomb[i]}");
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите высоту ромба (нечетное число > 3): ");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите символ, из которого будет состоять ромб: ");
            char symbol = Convert.ToChar(Console.ReadLine());
            
            Console.Write("Залить фигуру? (y/n): ");
            bool isFilled = Console.ReadLine() == "y" ? true : false;

            string[] rhomb = GetRhomb(height, symbol, isFilled);

            PrintRhomb(rhomb);
        }
    }
}
