using MinefieldGame.Interfaces;
using System;


namespace MinefieldGame.Domain
{
    /// <summary>
    /// Displays positions and generic messages to the player.
    /// </summary>
    public class OutputManager : IOutputManager
    {
        /// <summary>
        /// Displays the specified message.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void DisplayMessage(string message)
        {
            // Displays the message on the console.
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays the position details along with the status of mine hit.
        /// </summary>
        /// <param name="positionName">The name of the position.</param>
        /// <param name="livesRemaining">The remaining lives.</param>
        /// <param name="totalMovesTaken">The total moves taken.</param>
        /// <param name="mineHit">Specifies if a mine was hit at the position.</param>
        public void DisplayPosition(string positionName, int livesRemaining, int totalMovesTaken, bool mineHit)
        {
            // Prepares a message indicating if a mine was hit or not.
            string boom = mineHit ? " *Boom!*" : string.Empty;

            // Displays the position details along with the mine hit status.
            Console.WriteLine($"{positionName}  |  Lives Remaining: {livesRemaining}  |  Total Moves: {totalMovesTaken}.  {boom}");
        }
    }
}
