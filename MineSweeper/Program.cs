using System;

namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Type the width of the map:");
            byte width;
            try
            {
                width = byte.Parse(Console.ReadLine());
            }
            catch
            {
                width = 0;
            }
            if(width < 10) { width = 10; }
            Console.WriteLine("Type the height of the map:");
            byte height;
            try
            {
                height = byte.Parse(Console.ReadLine());
            }
            catch
            {
                height = 0;
            }
            if (height < 10) { height = 10; }
            Console.WriteLine("How many mines do you want?");
            byte mines;
            try
            {
                mines = byte.Parse(Console.ReadLine());
            }
            catch
            {
                mines = 0;
            }
            if (mines < 1) { mines = 1; }
            Map mapa = new Map(width, height, mines);


            bool run = true;

            mapa.Draw();
            while (run)
            {
                //Inputs
                Tuple<byte, byte> coords = Inputs(mapa.Width, mapa.Height);
                //Logica
                if(mapa.Visibilizar(coords.Item1, coords.Item2))
                {
                    run = false;
                    mapa.Visibilizar();
                }
                else
                {

                }
                //Dibujado
                Console.Clear();
                mapa.Draw();
            }

        }


        static Tuple<byte,byte> Inputs(byte width, byte height)
        {
            Console.WriteLine("Coord X:");
            byte X;
            try
            {
                X = byte.Parse(Console.ReadLine());
            }
            catch
            {
                X = 0;
            }
            if (X >= width) { X = (byte)(width - 1); }
            Console.WriteLine("Coord Y:");
            byte Y;
            try
            {
                Y = byte.Parse(Console.ReadLine());
            }
            catch
            {
                Y = 0;
            }
            if (Y >= height) { Y = (byte)(height - 1); }
            return new Tuple<byte, byte>(X, Y);
        }
    }
}
