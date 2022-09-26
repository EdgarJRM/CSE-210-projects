using System;

namespace Unit01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tic Tac Toe for Edgar Rodríguez
            Console.WriteLine("Welcome to Tic Tac Toe!");
            string [] arraytable = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            printTable(arraytable); //Print the game board
            Console.WriteLine();
            
            string player = "x";
            string input = "star";
            while (input == "star"){
                string userResponse = Response(arraytable,player);
                arraytable = (string[])table(arraytable, userResponse, player);
                string winner = reviewWinner (arraytable); 

                if (winner == "Yes"){
                    input = "End";
                    Console.WriteLine($"{player}'s the winner. Good game. Thanks for playing!");
                }else if (winner == "Tie"){
                    input = "End";
                    Console.WriteLine($"It is Tie");
                }

                if (player == "x"){
                    player = "o";
                }else{
                    player = "x";
                }
            }  
        }

        public static Array table (string[] arraytable, string userResponse, string player){
            // this function inserts the user's response into the array
            arraytable[int.Parse(userResponse)-1] = player;
            printTable(arraytable);
            return arraytable;
        }

        public static void printTable (string[] answer){
            // Print the array
            Console.WriteLine($"{answer[0]}|{answer[1]}|{answer[2]}");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"{answer[3]}|{answer[4]}|{answer[5]}");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"{answer[6]}|{answer[7]}|{answer[8]}");
            Console.WriteLine();
        }
        
        public static string reviewWinner (string[] arraytable){
            //Check if there is a winner on the board or tie
            string winner = "No";

            for (int i = 0; i < arraytable.Length ; i++){
                var stringNumber = arraytable[i];
                int numericValue;
                bool isNumber = int.TryParse(stringNumber, out numericValue);
                if (isNumber){ 
                    winner = "isNumber";
                }
            }
            if(winner != "isNumber" && winner == "No" ){
                winner = "Tie";
            }

            if (arraytable[0]==arraytable[1] && arraytable[1]==arraytable[2]){
                winner = "Yes";
            }else if(arraytable[3]==arraytable[4] && arraytable[4]==arraytable[5]){
                winner = "Yes";
            }else if(arraytable[6]==arraytable[7] && arraytable[7]==arraytable[8]){
                winner = "Yes";
            }else if(arraytable[0]==arraytable[4] && arraytable[4]==arraytable[8]){
                winner = "Yes";
            }else if(arraytable[1]==arraytable[4] && arraytable[4]==arraytable[7]){
                winner = "Yes";
            }else if(arraytable[2]==arraytable[4] && arraytable[4]==arraytable[6]){
                winner = "Yes";
            }else if(arraytable[0]==arraytable[3] && arraytable[3]==arraytable[6]){
                winner = "Yes";
            }
            else if(arraytable[1]==arraytable[4] && arraytable[4]==arraytable[7]){
                winner = "Yes";
            }
            else if(arraytable[2]==arraytable[5] && arraytable[5]==arraytable[8]){
                winner = "Yes";
            }

        return winner;
        }

        public static string Response (string[] arraytable, string player){
            //Check if there is a winner on the board
            string input = "yes";
            string userResponse = "";
            while (input == "yes"){
                Console.Write($"{player}'s turn to choose a square (1-9):");
                userResponse =  Console.ReadLine();

                int position = int.Parse(userResponse);
                if (position < 0 || position> 10){
                    Console.WriteLine("It is not a valid value");

                }
                if (arraytable[position-1]== "x" ||arraytable[position-1]== "o"){
                    Console.WriteLine("position is occupied");
                }else{
                    input = "no";
                    
                }
            }
            
            return userResponse;
        }
    }
}
