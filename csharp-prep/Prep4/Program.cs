using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 4");

            List<int> numbers = new List<int>();
            
            int userNumber = -1;
            while (userNumber != 0){
                Console.Write("Enter a number (0 to quit): ");
                
                string userResponse = Console.ReadLine();
                userNumber = int.Parse(userResponse);
                
                numbers.Add(userNumber);
            }

            // Sum
            int sum = 0;
            foreach (int number in numbers){
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");

            // The average
            float average = sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            //The max
            int max = numbers[0];
            foreach (int number in numbers){
                if (number > max){
                    max = number;
                }
            }

            Console.WriteLine($"The max is: {max}");
            
        }
    }
}
