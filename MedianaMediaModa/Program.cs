using System;
using System.Collections;
using System.Collections.Generic;

namespace MedianaMediaModa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lista = new MyList<int>();

            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                lista.Add(rnd.Next(100));
            }
            Console.WriteLine("Escribe un numero a buscar:");
            string response = Console.ReadLine();
            int busqueda = -1;
            int.TryParse(response, out busqueda);


            //if (lista.Search(busqueda))
            //{
            //    Console.WriteLine("Tiene el elemento");
            //}
            //else
            //{
            //    Console.WriteLine("No tiene el elemento");
            //}
        }
    }
}
