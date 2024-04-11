namespace MinefieldGame.Domain
{
    /// <summary>
    /// The contract for a game board
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// The length of the board.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Returns true when the specied coordinates are within the board boundries.
        /// </summary>
        /// <param name="rankLabel"></param>
        /// <param name="filePosition"></param>
        /// <returns></returns>
        bool IsWithinBounds(int rankLabel, int filePosition);

        /// <summary>
        /// Returns the position of the given row column corordinates in chess board terminology.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        string Position(int rank, int file);
    }
}