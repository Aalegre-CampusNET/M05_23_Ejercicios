using System;
using System.IO;

namespace Directory_filer
{
    internal class Program
    {
        private const string FORMAT_FILE = "yyyy-MM-dd_hh-mm-ss-fff";
        private const string FORMAT_LOG = "yyyy/MM/dd HH:mm:ss.fff";

        private static void Main(string[] args)
        {
            Console.WriteLine("Seleccionar carpeta:");
            string path1 = Console.ReadLine();
            Console.WriteLine("Seleccionar busqueda:");
            string searchPattern = Console.ReadLine();
            Console.WriteLine("Separar por carpetas(y/n)?");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Total archivos encontrados ; " + Directory.GetFiles(path1, searchPattern, SearchOption.AllDirectories).Length.ToString());
                string[] directories = Directory.GetDirectories(path1);
                foreach (string path2 in directories)
                    Console.WriteLine(path2 + " ; " + Directory.GetFiles(path2, searchPattern, SearchOption.AllDirectories).Length.ToString());
                Console.WriteLine("Desea listar todos los archivos encontrados (y/n)?");
                if (Console.ReadLine().ToLower() == "y")
                {
                    foreach (string path3 in directories)
                    {
                        string[] files = Directory.GetFiles(path3, searchPattern, SearchOption.AllDirectories);
                        Console.WriteLine(path3 + " ; " + files.Length.ToString());
                        foreach (string str in files)
                            Console.WriteLine(str);
                    }
                }
            }
            else
            {
                string[] files = Directory.GetFiles(path1, searchPattern, SearchOption.AllDirectories);
                Console.WriteLine("Total archivos encontrados ; " + files.Length.ToString());
                Console.WriteLine("Desea listar todos los archivos encontrados (y/n)?");
                if (Console.ReadLine().ToLower() == "y")
                {
                    foreach (string str in files)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            Console.WriteLine("Pulse una tecla para finalizar...");
            Console.ReadKey();
        }
    }
}

