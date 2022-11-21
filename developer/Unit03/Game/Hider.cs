using System;
using System.Collections.Generic;


namespace Unit03.Game 
{
    /// <summary>
    /// <para>The person hiding from the Seeker.</para>
    /// <para>
    /// The responsibility of Hider is to keep track of its location and distance from the seeker.
    /// </para>
    /// </summary>
    public class Hider
    {
        public string _word = "Templo";
        private string [] _arrayWord = new string []{"alien", "apple", "banks", "cards", "dance", "files", "hours", "ideas", "japan", "level", "mouth", "names", "party", "queen", "rings", "sleep", "users", "votes", "words", "years"};
        private string [] _board = new string []{"_", "_", "_", "_", "_"};
        private int _lost = 0;
        private bool finish = false;
        
        private string myletter = "";

        /// <summary>
        /// Constructs a new instance of Hider. 
        /// </summary>
        public Hider()
        {
            //
            Random random = new Random();
            int _location = random.Next(_arrayWord.Length - 1);
            // start with two so GetHint always works. Assign a random word
            _word = _arrayWord[_location];
            Console.WriteLine($"{_board[0]} {_board[1]} {_board[2]} {_board[3]} {_board[4]}");
            Console.WriteLine(@"    ____");
            Console.WriteLine(@"   /____\");
            Console.WriteLine(@"   \    /");
            Console.WriteLine(@"    \  /");
            Console.WriteLine(@"      0");
            Console.WriteLine(@"     /|\");
            Console.WriteLine(@"     / \");
            Console.WriteLine("");
            Console.WriteLine("________________");

        }

        /// <summary>
        /// Gets a hint for the seeker.
        /// </summary>
        /// <returns>A new hint.</returns>
        public string GetHint()
        {
            //We create an array to hold each letter of the word
            string [] letters = new string [_word.Length];
            bool a = false;

            for(int i = 0; i <_word.Length; i++){
                letters[i] = _word.Substring(i,1);
                if (letters[i] == myletter){
                    _board[i] = myletter;
                    a = true;
                }

            }
            Console.WriteLine($"{_board[0]} {_board[1]} {_board[2]} {_board[3]} {_board[4]}");

            //We determine if the chosen letter has been wrong
            string hint = "";
            if(a == false){
                _lost = _lost + 1;
            }

            //We show graphically with the parachute if the answer is correct or not
            if (_lost == 0){
                Console.WriteLine(@"    ____");
                Console.WriteLine(@"   /____\");
                Console.WriteLine(@"   \    /");
                Console.WriteLine(@"    \  /");
                Console.WriteLine(@"      0");
                Console.WriteLine(@"     /|\");
                Console.WriteLine(@"     / \");
                Console.WriteLine("");
                Console.WriteLine("________________");

            }else if (_lost == 1){
                Console.WriteLine("");
                Console.WriteLine(@"   /____\");
                Console.WriteLine(@"   \    /");
                Console.WriteLine(@"    \  /");
                Console.WriteLine(@"      0");
                Console.WriteLine(@"     /|\");
                Console.WriteLine(@"     / \");
                Console.WriteLine("");
                Console.WriteLine("________________");
            }else if (_lost == 2){
                Console.WriteLine("");
                Console.WriteLine(@"   \    /");
                Console.WriteLine(@"    \  /");
                Console.WriteLine(@"      0");
                Console.WriteLine(@"     /|\");
                Console.WriteLine(@"     / \");
                Console.WriteLine("");
                Console.WriteLine("________________");                
            }else if (_lost == 3){
                Console.WriteLine("");
                Console.WriteLine(@"    \  /");
                Console.WriteLine(@"      0");
                Console.WriteLine(@"     /|\");
                Console.WriteLine(@"     / \");
                Console.WriteLine("");
                Console.WriteLine("________________");                
            }else if (_lost == 4){
                Console.WriteLine("");
                Console.WriteLine(@"      x");
                Console.WriteLine(@"     /|\");
                Console.WriteLine(@"     / \");
                Console.WriteLine("");
                Console.WriteLine("________________"); 
                Console.WriteLine("");
                finish = true;
                Console.WriteLine($"Sorry, you have failed!");
                finish = true;
                hint = $"The word was : {_word}";
            }
            
            //We check if we have won the game. 
            //This can also be applied in the IsFound() function.
            if (_board[0] != "_" && _board[1] != "_" && _board[2] != "_" && _board[3] != "_" && _board[4] != "_"){
                finish = true;
                hint = "Congratulation, you win!!";
            }

            return hint;
        }

        /// <summary>
        /// Whether or not the hider has been found.
        /// </summary>
        /// <returns>True if found; false if otherwise.</returns>
        public bool IsFound()
        {
            return finish;
        }

        /// <summary>
        /// Watches the seeker by keeping track of how far away it is.
        /// </summary>
        /// <param name="seeker">The seeker to watch.</param>
        public void WatchSeeker(Seeker seeker)
        {
            myletter = seeker.GetLetter();

        }
    }
}