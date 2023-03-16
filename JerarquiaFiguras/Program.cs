using System;

namespace JerarquiaFiguras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Cuadrado cuadrado= new Cuadrado();
            cuadrado.Base = 10;
            Console.WriteLine(cuadrado.Area());
            Console.WriteLine(cuadrado.Perimeter());

            Figura figura = new Rectangulo();

            int entero = 0;


        }
    }
}
