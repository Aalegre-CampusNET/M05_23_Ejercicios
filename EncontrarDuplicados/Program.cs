using System;
using System.Collections.Generic;

namespace EncontrarDuplicados
{
    public class Program
    {
        const string letters = "abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            List<string> list = GenerateRandomWords(10000);

            bool hayDuplicadas = CheckDuplicates(list);
            if (hayDuplicadas)
            {
                Console.WriteLine("Hay duplicados");
            }
            else
            {
                Console.WriteLine("No hay duplicados");
            }
        }

        static public List<string> GenerateRandomWords(int n)
        {
            Random rand = new Random();
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string palabra = "";
                for (int j = 0; j < 3; j++)
                {
                    palabra += letters[rand.Next(letters.Length)];
                }
                list.Add(palabra);
            }
            return list;
        }

        static public bool CheckDuplicates(List<string> list)
        {
            List<string> duplicadas = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                string palabracomp = list[i];
                for (int j = 0; j < list.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    if (palabracomp == list[j])
                    {
                        duplicadas.Add(palabracomp);
                        break;
                    }
                }
            }

            return duplicadas.Count > 0;
        }

    }
}
