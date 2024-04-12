using MinefieldGame.Helpers;
using MinefieldGame.Interfaces;


namespace MinefieldGame.Domain
{
    /// <summary>
    /// Represents a game board with rows and columns.
    /// </summary>
    public abstract class GameBoard : IGameBoard
    {
        /// <summary>
        /// The current _row position.
        /// </summary>
        protected int _row;

        /// <summary>
        /// The current _column position.
        /// </summary>
        protected int _column;

        /// <summary>
        /// The size of the board.
        /// </summary>
        protected readonly int _boardSize;

        /// <summary>
        /// Moves the position up one step if within bounds.
        /// </summary>
        public void MoveUp()
        {
            if (IsWithinBounds(_row + 1, _column))
                _row++;
        }

        /// <summary>
        /// Moves the position down one step if within bounds.
        /// </summary>
        public void MoveDown()
        {
            if (IsWithinBounds(_row - 1, _column))
                _row--;
        }

        /// <summary>
        /// Moves the position left one step if within bounds.
        /// </summary>
        public void MoveLeft()
        {
            if (IsWithinBounds(_row, _column - 1))
                _column--;
        }

        /// <summary>
        /// Moves the position right one step if within bounds.
        /// </summary>
        public void MoveRight()
        {
            if (IsWithinBounds(_row, _column + 1))
                _column++;
        }

        /// <summary>
        /// Gets the size of the board.
        /// </summary>
        public int Size => Constants.BoardSize;

        /// <summary>
        /// Checks if the given position is within the board boundaries.
        /// </summary>
        /// <param name="newrow">The _row of the position.</param>
        /// <param name="newcol">The _column of the position.</param>
        /// <returns>True if within bounds, otherwise false.</returns>
        public bool IsWithinBounds(int newrow, int newcol)
        {
            return newrow >= 1 && newrow <= Size && newcol >= 1 && newcol <= Size;
        }

        /// <summary>
        /// Returns the position of the current coordinate in chess board terminology.
        /// </summary>
        /// <returns>The position string.</returns>
        public string CurrentPosition()
        {
            return GetPosition(_row, _column);
        }

        /// <summary>
        /// Returns the position of the given coordinate in chess board terminology.
        /// </summary>
        /// <param name="rank">The rank of the position.</param>
        /// <param name="file">The file of the position.</param>
        /// <returns>The position string.</returns>
        public string GetPosition(int rank, int file)
        {
            return $"{(char)(file + Constants.ASCIIcodePrefix)}{rank}";
        }
    }

}
