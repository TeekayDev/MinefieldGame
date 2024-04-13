using MinefieldGame.Interfaces;

namespace MinefieldGame.Domain
{
    /// <summary>
    /// Represents a player in the game.
    /// </summary>
    public class Player : IPlayer
    {
        private int totalLives;
        private int totalMoves;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the specified initial lives.
        /// </summary>
        /// <param name="initialLives">The initial number of lives for the player.</param>
        public Player(int initialLives)
        {
            totalLives = initialLives;
            totalMoves = 0;
        }

        /// <summary>
        /// Gets the remaining lives of the player.
        /// </summary>
        public int LivesRemaining => totalLives;

        /// <summary>
        /// Gets the total moves taken by the player.
        /// </summary>
        public int TotalMovesTaken => totalMoves;

        /// <summary>
        /// Decrements the lives of the player by 1.
        /// </summary>
        public void DecrementLives()
        {
            totalLives--;
        }

        /// <summary>
        /// Increments the total moves taken by the player by 1.
        /// </summary>
        public void IncrementMoves()
        {
            totalMoves++;
        }
    }
}
