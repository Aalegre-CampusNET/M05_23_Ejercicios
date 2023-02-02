using System;
using System.Collections.Generic;

namespace LoginSystem
{
    public class Program
    {
        static Dictionary<string, string> users = new Dictionary<string, string>()
        {
            {"alberto", "1234" },
            {"albert", "12345" },
            {"ruben", "123" },
            {"jesucristo", "superstar" },
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce usuario:");
            string user = Console.ReadLine();
            Console.WriteLine("Introduce contraseña:");
            string pass = Console.ReadLine();
            if(Login(user, pass))
            {
                Console.WriteLine("Has iniciado sesión");
            }
            else
            {
                Console.WriteLine("La combinacion de usuario y contraseña no está registrada.");
            }
        }

        public static bool Login(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                if (users[username] == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
