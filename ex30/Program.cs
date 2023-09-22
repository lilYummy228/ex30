using System;

namespace ex30
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userPositionX = 1, userPositionY = 1;
            bool isGameOver = true;
            bool isStarTaken = true;
            char hero = '@';

            while (isGameOver)
            {
                char[,] map = DrawMap();

                Console.SetCursorPosition(userPositionY, userPositionX);
                Console.Write(hero);
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                isStarTaken = MoveHero(map, pressedKey, ref userPositionX, ref userPositionY, isStarTaken);

                if (isStarTaken == false)
                {
                    DrawMap();

                    Console.SetCursorPosition(userPositionY, userPositionX);
                    Console.Write(hero);
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Вы собрали звезду! Уровень пройден!");
                    isGameOver = false;
                }
            }
        }

        static char[,] DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;

            char[,] map = CreateMap();

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

        static bool MoveHero(char[,] map, ConsoleKeyInfo pressedKey, ref int userPositionX, ref int userPositionY, bool isStarTaken)
        {
            int[] direction = GetDirection(pressedKey);

            char wall = '#';
            char enemy = 'X';
            char star = '*';
            int nextUserPositionX = userPositionX + direction[0];
            int nextUserPositionY = userPositionY + direction[1];

            if (map[nextUserPositionX, nextUserPositionY] != wall)
            {
                userPositionX = nextUserPositionX;
                userPositionY = nextUserPositionY;

                if (map[userPositionX, userPositionY] == enemy)
                {
                    userPositionX = 1;
                    userPositionY = 1;
                }
                else if (map[userPositionX, userPositionY] == star)
                {
                    userPositionX = nextUserPositionX;
                    userPositionY = nextUserPositionY;
                    isStarTaken = false;
                }
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

        static char[,] CreateMap()
        {
            char[,] map = {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#',' ','#',' ',' ',' ',' ',' ','#',' ',' ','X',' ',' ',' ',' ','#',' ',' ',' ','X','#'},
                {'#',' ','#',' ','#','#','#',' ','#',' ','#','#',' ','#','#','X',' ',' ','#',' ','#','#'},
                {'#',' ','#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ','#','#',' ','#','#',' ',' ','#'},
                {'#',' ','#','#','#',' ','#','#','#',' ',' ',' ','#',' ',' ',' ',' ','#','#','#',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ','X',' ',' ','#','#','#',' ','#','#','#','#',' ','#',' ','#'},
                {'#',' ','#','#','#',' ','#','#','#',' ','#',' ',' ',' ',' ',' ',' ',' ','X','#',' ','#'},
                {'#',' ','#',' ','#',' ','#',' ',' ',' ','#',' ','#',' ','#',' ','#','#',' ','#',' ','#'},
                {'#',' ','#',' ',' ',' ','#',' ','#',' ','#',' ','#','X','#',' ',' ','X',' ',' ',' ','#'},
                {'#',' ','#','#','#','X',' ',' ','#',' ','#',' ',' ',' ','#',' ','#','#','#','#',' ','#'},
                {'#',' ',' ',' ','#','#','#','#','#',' ','#','#','#',' ','#',' ','#',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','X',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ','#','#','X','#'},
                {'#',' ','#',' ','#','#',' ','#','#','#',' ','#','#',' ',' ',' ','#',' ','#','*','#','#'},
                {'#',' ','#',' ',' ','X',' ',' ','X','#',' ','#','#',' ','#','#','#',' ','X',' ',' ','#'},
                {'#',' ','#',' ','#','#',' ','#',' ','#',' ','#','#',' ','#','#','#',' ','#','#',' ','#'},
                {'#',' ','#',' ',' ',' ',' ','#',' ',' ',' ','#',' ',' ','#',' ',' ',' ','X',' ',' ','#'},
                {'#',' ','#',' ','#','#','#','#','#','#',' ','#','X','#','#',' ','#','#','#',' ','#','#'},
                {'#',' ','#',' ','X',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ',' ',' ','#',' ',' ','#'},
                {'#',' ','#','#','#','#','#',' ','#',' ','#','#',' ','#','#','#','#','X','#','#',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','X',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
            };
            return map;
        }
    }
}
