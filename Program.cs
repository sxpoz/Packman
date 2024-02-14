using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace packman_v1._1
{
    internal class Program
    {
        static void DrawMap(char[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }
        static char[,] FillMap(string[] file)
        {
            char[,] map = new char[file.Length, file[0].Length];
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[x][y];
                }
            }
            return map;
        }
        static void Main(string[] args)
        {
            char[,] map = FillMap(File.ReadAllLines("map.txt"));
            DrawMap(map);
            char character = '@';
            int charX = 2, charY = 4;
            Console.SetCursorPosition(charY, charX);
            Console.Write(character);
            Console.CursorVisible = false;
            ConsoleKeyInfo key = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            Task.Run(() =>
            {
                while (true)
                {
                    key = Console.ReadKey();
                }
            });

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                DrawMap(map);
                switch (key.Key)
                {
                    case ConsoleKey.W:
                    {
                            if (map[charX - 1, charY] != '#') charX--;
                            break;
                    }

                    case ConsoleKey.S:
                    {
                            if (map[charX + 1, charY] != '#') charX++;
                            break;
                    }
                    case ConsoleKey.A:
                    {
                        if (map[charX, charY - 1] != '#') charY--;
                        break;
                    }
                    case ConsoleKey.D:
                    {
                        if (map[charX, charY + 1] != '#') charY++;
                        break;
                    }
                }
                Console.SetCursorPosition(charY, charX);
                Console.Write(character);

                Console.SetCursorPosition(30, 0);
                Console.Write("Pressed key: ");

                Thread.Sleep(100);
            }
        }
    }
}
