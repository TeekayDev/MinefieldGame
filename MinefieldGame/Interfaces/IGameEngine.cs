using System;

namespace MinefieldGame.Interfaces
{
    /// <summary>
    /// Represents the game engine controlling player movements and game state.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Gets a value indicating whether the game is still in play.
        /// </summary>
        bool StillInPlay { get; }

        /// <summary>
        /// Moves the player based on the input key.
        /// </summary>
        /// <param name="keyInfo">The input key.</param>
        void Move(ConsoleKeyInfo keyInfo);

        /// <summary>
        /// Gets the current position of the player.
        /// </summary>
        string CurrentPosition { get; }

        /// <summary>
        /// Gets a value indicating whether the player has hit a mine.
        /// </summary>
        bool IsMineHit { get; }

        /// <summary>
        /// Gets the remaining lives of the player.
        /// </summary>
        int LivesRemaining { get; }

        /// <summary>
        /// Gets the total number of moves taken by the player.
        /// </summary>
        int TotalMovesTaken { get; }

        /// <summary>
        /// Gets a value indicating whether the game is completed.
        /// </summary>
        bool Completed { get; }

        /// <summary>
        /// Checks if the player input is valid.
        /// </summary>
        /// <param name="keyInfo">The input key.</param>
        /// <returns>True if the game is still in play, otherwise false.</returns>
        bool PlayerInput(ConsoleKeyInfo keyInfo);
    }

}