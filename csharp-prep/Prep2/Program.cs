using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 2");
            
            Console.WriteLine("What is your grade percent? ");
            string valueFromUser = Console.ReadLine();
            int grade = int.Parse(valueFromUser);
            string letter = "";

            if (grade >= 90) {
                letter = "A";
            }else if (grade >= 80){
                letter = "B";
            }else if (grade >= 70) {
                letter = "C";
            }else if (grade >= 60) {
                letter = "D";
            }else{
                letter = "F";
            }
            Console.WriteLine($"Your letter grade is: {letter}");

            if (letter == "A" || letter ==  "B" || letter ==  "C" || letter == "D") {
                Console.WriteLine("Congratulations! You passed the class!");
            }else{
                Console.WriteLine("Stay focused and you'll get it next time!");
            }
        }
    }
}
