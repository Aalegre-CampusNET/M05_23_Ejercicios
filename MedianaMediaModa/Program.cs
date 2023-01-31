using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MedianaMediaModa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> lista = new HashSet<int>();

            Random rnd = new Random();

            //Prueba de rellenado
            for (int i = 0; i < 10000000; i++)
            {
                lista.Add(rnd.Next(100));
            }

            //Prueba de acceso
            for (int i = 0; i < lista.Count; i++)
            {
                int temp = lista.ElementAt(i);
            }

            //Prueba de búsqueda
            for (int i = 0; i < 100000; i++)
            {
                lista.Contains(rnd.Next(100));
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
