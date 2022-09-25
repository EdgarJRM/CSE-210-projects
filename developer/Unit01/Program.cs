using System;

namespace Unit01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toc!");
            table("x", "5");
        }

        public static void table (string answer, string position){
            Console.WriteLine($"1|2|3");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"4|5|6");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"7|8|9");
        }
    }
}
