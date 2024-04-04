using System;
using System.IO;

namespace BAA_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string mapFileName = "map.txt";
            char playerSymbol = '&';
            char endPoint = 'X';
            char[,] map;
            bool isEndGame = false;
            int playerStepValue = 1;
            Console.CursorVisible = false;

            Console.Write("Лабиринт\nВведите ваше кол-во здоровья: ");
            int healthBar = Convert.ToInt32(Console.ReadLine()); healthBar += 1;

            map = ReadMap(mapFileName);

            GetPositionEndPoint(map, endPoint, out int endLevelX, out int endLevelY);

            while (isEndGame == false)
            {
                Console.Clear();

                healthBar--;
                Console.WriteLine("Кол-во ходов: " + healthBar);
                if (healthBar == 0)
                {
                    Console.WriteLine("Лабиринт не пройден!");
                    break;
                }

                ShowMap(map);

                GetPlayerPosition(map, playerSymbol, out int playerX, out int playerY);

                GetCommandFromPlayer(playerStepValue, out int playerDeltaX, out int playerDeltaY);

                map = TryChangePlayerPosition(map, playerSymbol, playerX, playerY, playerDeltaX, playerDeltaY,
                    out int playerXNext,
                    out int playerYNext);

                isEndGame = CheckEndLevel(playerXNext, playerYNext, endLevelX, endLevelY);
            }
            Console.Clear();
            Console.WriteLine("Конец");
            Console.ReadKey();
        }

        static char[,] ReadMap(string mapFileName)
        {
            string[] tempMap = File.ReadAllLines(mapFileName);

            int maxIMap = tempMap.Length;
            int maxJMap = tempMap[0].ToCharArray().Length;

            char[,] map = new char[maxIMap, maxJMap];

            for (int i = 0; i < maxIMap; i++)
            {
                for (int j = 0; j < maxJMap; j++)
                {
                    map[i, j] = tempMap[i].ToCharArray()[j];
                }
            }
            return map;
        }

        static void GetPositionEndPoint(char[,] map, char endLevelSymbol, out int endLevelX, out int endLevelY)
        {
            endLevelX = 0; endLevelY = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == endLevelSymbol)
                    {
                        endLevelX = j; endLevelY = i;
                    }
                }
            }
        }

        static void ShowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void GetPlayerPosition(char[,] map, char player, out int playerX, out int playerY)
        {
            playerY = 0; playerX = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == player)
                    {
                        playerX = j; playerY = i;
                    }
                }
            }
        }

        static void GetCommandFromPlayer(int playerStep, out int playerDeltaX, out int playerDeltaY)
        {
            playerDeltaY = 0; playerDeltaX = 0;

            ConsoleKey command = Console.ReadKey().Key;

            switch (command)
            {
                case ConsoleKey.UpArrow:
                    playerDeltaX = playerStep * 0;
                    playerDeltaY = playerStep * -1;
                    break;

                case ConsoleKey.DownArrow:
                    playerDeltaX = playerStep * 0;
                    playerDeltaY = playerStep * 1;
                    break;

                case ConsoleKey.LeftArrow:
                    playerDeltaX = playerStep * -1;
                    playerDeltaY = playerStep * 0;
                    break;

                case ConsoleKey.RightArrow:
                    playerDeltaX = playerStep * 1;
                    playerDeltaY = playerStep * 0;
                    break;

                default:
                    playerDeltaX = playerStep * 0;
                    playerDeltaY = playerStep * 0;
                    break;
            }
        }

        static char[,] TryChangePlayerPosition(char[,] map, char playerSumbol, int playerX, int playerY,
            int playerDeltaX, int playerDeltaY, out int playerXNext, out int playerYNext)
        {
            playerXNext = playerX;
            playerYNext = playerY;

            if (map[playerY + playerDeltaY, playerX + playerDeltaX] != '#')
            {
                map[playerY + playerDeltaY, playerX + playerDeltaX] = playerSumbol;
                map[playerY, playerX] = ' ';

                playerXNext = playerX + playerDeltaX;
                playerYNext = playerY + playerDeltaY;
            }
            return map;
        }

        private static bool CheckEndLevel(int playerX, int playerY, int endLevelX, int endLevelY)
        {
            bool isEnd = false;

            if (playerX == endLevelX & playerY == endLevelY)
            {
                isEnd = true;
            }
            return isEnd;
        }
    }
} 
