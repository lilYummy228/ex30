using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ex30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userX = 1, userY = 1;
            bool isGameOver = true;
            bool isStarTaken = true;

            while (isGameOver)
            {
                char[,] map = DrawMap();

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                isStarTaken = MoveHero(map, pressedKey, ref userX, ref userY, isStarTaken);

                if (isStarTaken == false)
                {
                    DrawMap();

                    Console.SetCursorPosition(userY, userX);
                    Console.Write('@');
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("Вы собрали звезду! Уровень пройден!");
                    isGameOver = false;
                }
            }
        }

        static char[,] DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            char[,] map = {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#',' ',' ',' ',' ',' ',' ','#',' ','X',' ',' ',' ','#'},
                {'#',' ','#','#','#','#','X','#',' ','#','#','#',' ','#'},
                {'#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ','#'},
                {'#',' ','#','X','#','#',' ','#','#','#',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#',' ','#','*','#','X','#',' ','#'},
                {'#',' ','#','#',' ',' ',' ','#',' ',' ',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
            };


            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }

            return map;
        }

        static bool MoveHero(char[,] map, ConsoleKeyInfo pressedKey, ref int userX, ref int userY, bool isStarTaken)
        {
            int[] direction = GetDirection(pressedKey);
            int nextUserPositionX = userX + direction[0];
            int nextUserPositionY = userY + direction[1];

            if (map[nextUserPositionX, nextUserPositionY] == ' ')
            {
                userX = nextUserPositionX;
                userY = nextUserPositionY;
            }
            else if (map[nextUserPositionX, nextUserPositionY] == 'X')
            {
                userX = 1;
                userY = 1;
            }
            else if (map[nextUserPositionX, nextUserPositionY] == '*')
            {
                userX = nextUserPositionX;
                userY = nextUserPositionY;
                isStarTaken = false;
            }

            return isStarTaken;
        }

        static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    direction[0] = -1;
                    break;

                case ConsoleKey.DownArrow:
                    direction[0] = 1;
                    break;

                case ConsoleKey.LeftArrow:
                    direction[1] = -1;
                    break;

                case ConsoleKey.RightArrow:
                    direction[1] = 1;
                    break;
            }

            return direction;
        }
    }
}
