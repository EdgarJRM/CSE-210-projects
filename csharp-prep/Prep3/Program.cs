using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 3");

            Random randomGenerator = new Random();
            int random = randomGenerator.Next(1, 100);
            // Console.WriteLine($"Random: {random}");
            int number = 0;
            while (random != number){
                Console.WriteLine("What is your guess? ");
                string valueFromUser = Console.ReadLine();
                number = int.Parse(valueFromUser);

                if (number > random) {
                    Console.WriteLine ("Lower");
                }else if (number < random){
                    Console.WriteLine("Higher");
                }else{
                    Console.WriteLine("You guessed it!");
                }
            }
        }
    }
}
