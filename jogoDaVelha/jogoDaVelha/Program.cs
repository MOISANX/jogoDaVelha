using JogoDaVelha;
using System;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "JogoDavelha Versão MOISANX";
            Console.BackgroundColor= ConsoleColor.White;
            Console.ForegroundColor= ConsoleColor.Black;
            Console.Clear();
            new JogoDaVelha().Menu();
        }
    }
}