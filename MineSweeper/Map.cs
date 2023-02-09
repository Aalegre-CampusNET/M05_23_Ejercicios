using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    internal class Map
    {
        public byte Width;
        public byte Height;
        public byte Mines;
        public List<List<Casilla>> mapa = new List<List<Casilla>>();

        public class Casilla
        {
            public bool Mine;
            public int Distance;
            public bool Visible;

            public Casilla(bool mine)
            {
                Mine = mine;
            }
        }

        public Map(byte width, byte height, byte mines)
        {
            Width = width;
            Height = height;
            Mines = mines;

            for (int i = 0; i < Height; i++)
            {
                mapa.Add(new List<Casilla>());
                for (int j = 0; j < Width; j++)
                {
                    mapa[i].Add(new Casilla(false));
                }
            }

            Random rand = new Random();

            for (int i = 0; i < Mines; i++)
            {
                int x = rand.Next(0, Width);
                int y = rand.Next(0, Height);
                mapa[y][x].Mine = true;
            }

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    try
                    {
                        if (mapa[y][x + 1].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                    try
                    {
                        if (mapa[y][x - 1].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                    try
                    {
                        if (mapa[y + 1][x].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                    try
                    {
                        if (mapa[y - 1][x].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                    try
                    {
                        if (mapa[y + 1][x + 1].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                    try
                    {
                        if (mapa[y - 1][x - 1].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                    try
                    {
                        if (mapa[y + 1][x - 1].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                    try
                    {
                        if (mapa[y - 1][x + 1].Mine)
                        {
                            mapa[y][x].Distance++;
                        }
                    }
                    catch { }
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (mapa[y][x].Visible)
                    {
                        if (mapa[y][x].Mine)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('X');
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            if (mapa[y][x].Distance == 0)
                            {
                                Console.Write(' ');
                            }
                            else
                            {
                                Console.Write(mapa[y][x].Distance);
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(' ');
                    }

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }

        public void Visibilizar()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    mapa[y][x].Visible = true;
                }
            }
        }
        public bool Visibilizar(byte X, byte Y)
        {
            if (mapa[Y][X].Visible) return false;
            if (mapa[Y][X].Mine)
            {
                return true;
            }
            else
            {
                mapa[Y][X].Visible = true;
                if (mapa[Y][X].Distance == 0)
                {
                    try { Visibilizar((byte)(Y - 1), (byte)(X)); } catch { }
                    try { Visibilizar((byte)(Y + 1), (byte)(X)); } catch { }
                    try { Visibilizar((byte)(Y), (byte)(X + 1)); } catch { }
                    try { Visibilizar((byte)(Y), (byte)(X - 1)); } catch { }
                    try { Visibilizar((byte)(Y - 1), (byte)(X + 1)); } catch { }
                    try { Visibilizar((byte)(Y - 1), (byte)(X - 1)); } catch { }
                    try { Visibilizar((byte)(Y + 1), (byte)(X + 1)); } catch { }
                    try { Visibilizar((byte)(Y + 1), (byte)(X - 1)); } catch { }
                }
                return false;
            }
        }
    }
}
