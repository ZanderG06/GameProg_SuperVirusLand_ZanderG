using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProg_SuperVirusLand_ZanderG
{
    internal class Program
    {
        static char[,] map =
        {
            { '~', '~', '~', '~', '~', '-', '-', '-', '-', '-'},
            { '~', '~', '~', '~', '~', '-', '-', '-', '-', '-'},
            { '~', '~', '~', '~', '-', '-', '-', '-', '-', '^'},
            { '-', '-', '-', '-', '-', '-', '-', '-', '^', '^'},
            { '-', '-', '-', '-', '-', '-', '-', '^', '^', '^'},
            { '-', '-', '-', '-', '-', '-', '-', '^', '^', '^'},
            { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            { '~', '~', '~', '-', '-', '-', '-', '-', '-', '-'},
            { '~', '^', '~', '-', '-', '-', '-', '-', '-', '-'}
        };

        static List<(int, int)> virus = new List<(int, int)>();
        static bool gameOver = false;
        static Random random = new Random();
        static int axisX;
        static int axisY;

        static void Main(string[] args)
        {
            for(int y = 0; y < map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y,x]);
                }
                Console.Write("\n");
            }
            
            virus.Add((5, 0));
            virus.Add((0, 3));
            virus.Add((9, 1));

            foreach ((int x, int y) in virus)
            {
                Console.SetCursorPosition(x,y);
                Console.Write("X");
            }

            while(gameOver == false)
            {
                
                Thread.Sleep(1000);
                virusMove();
            }
        }

        static void virusMove()
        {
            for(int i = 0; i < virus.Count; i++)
            {
                int direction = random.Next(4);

                if(direction == 0) //Up
                {
                    int border = virus[i].Item2 - 1;
                    axisX = virus[i].Item1;
                    axisY = virus[i].Item2;
                    
                    if (border < 0)
                    {
                        
                    }
                    else
                    {
                        
                        virus[i] = (virus[i].Item1, virus[i].Item2 - 1);
                        DuplicateVirus();
                    }
                }
                else if(direction == 1) //Left
                {
                    int border = virus[i].Item1 - 1;
                    axisX = virus[i].Item1;
                    axisY = virus[i].Item2;

                    if (border < 0)
                    {

                    }
                    else
                    {
                        virus[i] = (virus[i].Item1 - 1, virus[i].Item2);
                        DuplicateVirus();
                    }
                }
                else if (direction == 2) //Down
                {
                    int border = virus[i].Item2 + 1;
                    axisX = virus[i].Item1;
                    axisY = virus[i].Item2;

                    if (border > 9)
                    {

                    }
                    else
                    {
                        virus[i] = (virus[i].Item1, virus[i].Item2 + 1);
                        DuplicateVirus();
                    }
                }
                else if (direction == 3) //Right
                {
                    int border = virus[i].Item1 + 1;
                    axisX = virus[i].Item1;
                    axisY = virus[i].Item2;

                    if (border > 9)
                    {

                    }
                    else
                    {
                        virus[i] = (virus[i].Item1 + 1, virus[i].Item2);
                        DuplicateVirus();
                    }
                }
                else //Just Down again just in case it fails
                {
                    int border = virus[i].Item2 + 1;
                    axisX = virus[i].Item1;
                    axisY = virus[i].Item2;

                    if (border > 9)
                    {

                    }
                    else
                    {
                        virus[i] = (virus[i].Item1, virus[i].Item2 + 1);
                        DuplicateVirus();
                    }
                }
            }

            foreach ((int x, int y) in virus)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("X");
            }
        }

        static void DuplicateVirus()
        {
            int duplicate = random.Next(10);

            if(duplicate == 0)
            {
                Console.SetCursorPosition(axisX, axisY);
                Console.Write("X");
                virus.Add((axisX, axisY));
            }
            else
            {
                Console.SetCursorPosition(axisX, axisY);
                Console.Write("-");
            }
        }
    }
}
