namespace MinefieldGame.Interfaces
{
    /// <summary>
    /// Contract for displaying _positions and generic messages to an output medium
    /// </summary>
    public interface IOutputManager
    {
        /// <summary>
        /// Display generic message
        /// </summary>
        /// <param name="message"></param>
        void DisplayMessage(string message);
        
        /// <summary>
        /// Display in play messages
        /// </summary>
        /// <param name="positionName"></param>
        /// <param name="livesRemaining"></param>
        /// <param name="totalMovesTaken"></param>
        /// <param name="mineHit"></param>
        void DisplayPosition(string positionName, int livesRemaining, int totalMovesTaken, bool mineHit);
    }
}