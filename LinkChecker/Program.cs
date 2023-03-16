using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace LinkChecker
{
    internal class Program
    {
        private const int PERCENTAGE_DIVISION = 100;
        private const int TIMEOUT_SECONDS = 100;

        private static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Escribe la dirección del archivo:");
            try
            {
                string path = Console.ReadLine();
                string[] strArray = System.IO.File.ReadAllLines(path);
                int count = 0;
                List<Program.LinkStatus> links = new List<Program.LinkStatus>();
                Console.WriteLine("Leyendo fichero");
                foreach (string str in strArray)
                {
                    count++;
                    links.Add(new Program.LinkStatus()
                    {
                        original = str
                    });
                }
                Console.WriteLine("Encontradas " + links.Count.ToString() + "lineas");
                Console.WriteLine("Iniciando testeo de links");
                DateTime timeStart = DateTime.Now;
                count = 0;
                float totalPercentage = (float)links.Count / 100f;
                Parallel.For(0, links.Count, (Action<int, ParallelLoopState>)((i, state) =>
                {
                    Program.LinkStatus linkStatus = new Program.LinkStatus();
                    linkStatus.original = links[i].original;
                    try
                    {
                        if (!linkStatus.original.Contains("http://") && !linkStatus.original.Contains("https://"))
                            linkStatus.original = "http://" + linkStatus.original;
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(linkStatus.original));
                        httpWebRequest.Timeout = 100000;
                        HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                        linkStatus.response = response.StatusCode.ToString();
                        linkStatus.corrected = response.ResponseUri.ToString();
                        response.Close();
                    }
                    catch (WebException ex)
                    {
                        linkStatus.response = ex.Message;
                    }
                    catch (UriFormatException ex)
                    {
                        linkStatus.response = ex.Message;
                    }
                    catch (Exception ex)
                    {
                        linkStatus.response = ex.Message;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error:");
                        Console.WriteLine((object)ex);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    finally
                    {
                        lock (links)
                            links[i] = linkStatus;
                        ++count;
                        TimeSpan timeSpan1 = timeStart - DateTime.Now;
                        TimeSpan timeSpan2 = timeSpan1 / (double)count * (double)links.Count;
                        float num = (float)count / totalPercentage;
                        string str = timeSpan1.ToString("hh\\:mm\\:ss") + "/" + timeSpan2.ToString("hh\\:mm\\:ss") + " - [";
                        for (int index = 0; index < 100; ++index)
                            str = (double)(index + 1) >= (double)num ? str + "·" : str + "#";
                        Console.WriteLine(str + "]" + num.ToString("00.00") + "% - " + count.ToString() + "/" + links.Count.ToString() + "\n\t- " + linkStatus.corrected);
                    }
                }));
                Console.WriteLine();
                Console.WriteLine("Testeo de links finalizado, por favor espere que guardemos los resultados");
                using (StreamWriter streamWriter = new StreamWriter(path.Replace(Path.GetExtension(path), "") + "_corrected_" + DateTime.Now.ToString("yyyy_MM_dd-hh_mm_ss") + ".csv"))
                {
                    streamWriter.WriteLine("Original;Corregida;Estado");
                    foreach (Program.LinkStatus linkStatus in links)
                        streamWriter.WriteLine(linkStatus.original + ";" + linkStatus.corrected + ";" + linkStatus.response);
                }
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error:");
                Console.WriteLine((object)ex);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Proceso finalizado.");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public struct LinkStatus
        {
            public string original;
            public string corrected;
            public string response;
        }
    }
}