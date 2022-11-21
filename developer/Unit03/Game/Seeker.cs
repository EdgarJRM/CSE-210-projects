using System;


namespace Unit03.Game
{
    /// <summary>
    /// <para>The person looking for the Hider.</para>
    /// <para>
    /// The responsibility of a Seeker is to keep track of its location.
    /// </para>
    /// </summary>
    public class Seeker
    {
        private string _letter = "";

        /// <summary>
        /// Constructs a new instance of Seeker.
        /// </summary>
        public Seeker()
        {
            _letter = "temple";
        }

        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <returns>The current location.</returns>
        public string GetLetter()
        {
            return _letter;
        }

        /// <summary>
        /// Moves to the given location.
        /// </summary>
        /// <param name="location">The given location.</param>
        public void MoveLocation(string letter)
        {
            this._letter = letter;
        }

    }
}