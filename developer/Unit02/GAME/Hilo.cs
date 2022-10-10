using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Hilo{
        bool _isPlaying = true;
        int _score = 100;
        int _card1 = 0;
        int _card2 = 0;
        string chosenCard = "";

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Hilo(){
            Cards cards1 = new Cards();
            _card1 = cards1.draw();
            _card2 = cards1.draw();
 
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Asks the user if they want to roll.
        /// </summary>
        public void GetInputs(){
            Console.WriteLine($"The card is: {_card1}");
            Console.Write("Higher or Lower? [h/l] ");
            chosenCard = Console.ReadLine();
            Console.WriteLine($"The new card is: {_card2}");
            _isPlaying = (chosenCard == "h" || chosenCard == "l");
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            if (!_isPlaying)
            {
                return;
            }

            if (_card1 < _card2 && chosenCard == "h"){
                Console.WriteLine("Elección correcta");
                _score += 100;

            }else if (_card1 > _card2 && chosenCard == "l"){
                Console.WriteLine("Elección correcta");
                _score += 100;

            }else{
                Console.WriteLine("Elección incorrecta");
                _score = _score - 75;
            }
            Console.WriteLine($"You score is: {_score}");
        }

        /// <summary>
        /// Displays the dice and the score. Also asks the player if they want to roll again. 
        /// </summary>
        public void DoOutputs(){
            if (_score <= 0){
                _isPlaying = false;
                Console.WriteLine("Game Over");
            }

            if (!_isPlaying){
                return;
            }

            string values = "";
            Console.Write("Play again? [y/n] ");
            values = Console.ReadLine();
            if (values == "y"){
                _card1  = _card2;
                Cards cards1 = new Cards();
                _card2 = cards1.draw();
            }else if (values == "n"){
                _isPlaying = false;
                Console.WriteLine("Game Over");
            }            
        }
    }
}