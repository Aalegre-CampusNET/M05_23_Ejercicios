using System;
using System.Collections;
using System.Collections.Generic;

namespace HanoiTowers
{
    internal class Program
    {
        static Stack<int> A;
        static Stack<int> B;
        static Stack<int> C;
        static void Main(string[] args)
        {
            Console.WriteLine("Cuantos elementos quieres");
            int elementos = int.Parse(Console.ReadLine());
            if (elementos < 3)
                elementos = 3;
            Setup(elementos);
            Draw();
            while (!GameOver())
            {
                Tuple<char, char> response = Input();
                if (CheckMovement(response.Item1, response.Item2))
                {
                    Move(response.Item1, response.Item2);
                }
                else
                {
                    Console.WriteLine("Movimento no permitido");
                }
                Draw();
            }
            Console.WriteLine("Has ganado");
        }

        static void Setup(int count)
        {
            A = new Stack<int>();
            B = new Stack<int>();
            C = new Stack<int>();

            for (int i = count - 1; i >= 0; i--)
            {
                A.Push(i + 1);
            }

        }

        static Tuple<char, char> Input()
        {
            Console.WriteLine("De que pila quieres quitar un elemento");
            char desde = Console.ReadLine().ToLower()[0];
            Console.WriteLine("En que pila quieres colocar el elemento");
            char hasta = Console.ReadLine().ToLower()[0];
            return new Tuple<char, char>(desde, hasta);
        }

        static void Draw()
        {
            Console.Write("A: ");
            List<int> list = new List<int>();
            while(A.Count > 0)
            {
                Console.Write(A.Peek() + " ");
                list.Add(A.Pop());
            }
            Console.WriteLine();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                A.Push(list[i]);
            }

            Console.Write("B: ");
            list = new List<int>();
            while (B.Count > 0)
            {
                Console.Write(B.Peek() + " ");
                list.Add(B.Pop());
            }
            Console.WriteLine();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                B.Push(list[i]);
            }

            Console.Write("C: ");
            list = new List<int>();
            while (C.Count > 0)
            {
                Console.Write(C.Peek() + " ");
                list.Add(C.Pop());
            }
            Console.WriteLine();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                C.Push(list[i]);
            }
        }

        static bool GameOver()
        {
            return A.Count == 0 && B.Count == 0;
        }
        static bool CheckMovement(char from, char to)
        {
            if (from == to) return false;

            Stack<int> stackFrom = GetStack(from);
            Stack<int> stackTo = GetStack(to);

            if(stackFrom.Count == 0) return false;

            if (stackTo.Count == 0) return true;

            if (stackFrom.Peek() > stackTo.Peek()) return false;

            return true;
        }

        static void Move(char from, char to)
        {
            Stack<int> stackFrom = GetStack(from);
            Stack<int> stackTo = GetStack(to);

            stackTo.Push(stackFrom.Pop());
        }

        static Stack<int> GetStack(char stackName)
        {
            switch (stackName)
            {
                case 'a':
                    return A;
                case 'b':
                    return B;
                case 'c':
                    return C;
                default:
                    return null;
            }
        }
    }
}
