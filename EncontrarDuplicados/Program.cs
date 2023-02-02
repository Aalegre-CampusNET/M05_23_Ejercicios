using System;
using System.Collections.Generic;

namespace EncontrarDuplicados
{
    internal class Program
    {
        const string letters = "abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<string> list = new List<string>();
            List<string> duplicadas = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                string palabra = "";
                for (int j = 0; j < 3; j++)
                {
                    palabra += letters[rand.Next(letters.Length)];
                }
                list.Add(palabra);
            }
            list.Add(list[0]);

            string palabracomp = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                if (palabracomp == list[i])
                {
                    duplicadas.Add(palabracomp);
                    break;
                }
            }

        }
    }
}
