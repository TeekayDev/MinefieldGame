using MinefieldGame.Helpers;
using MinefieldGame.Interfaces;
using System;
using System.Data.Common;
using System.Linq;


namespace MinefieldGame.Domain
{
    public abstract class Board
    {
        protected int row;
        protected int column;
        protected readonly int _boardSize = 8;

        public Board()
        {

        }

        /// <summary>
        /// Returns the size of the board
        /// </summary>
        public int Size { get { return Constants.BoardSize; } }

        /// <summary>
        /// Returns true if the position coordinates are withing the board boundries
        /// </summary>
        /// <param name="rankLabel"></param>
        /// <param name="filePosition"></param>
        /// <returns></returns>
        public bool IsWithinBounds(int newrow, int newcol)
        {
            return newrow >= 1 && newrow <= this.Size && newcol >= 1 && newcol <= this.Size;
        }
             


        /// <summary>
        /// Returns the position of the coordinate in chess board terminology 
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public string CurrentPosition()
        {
            return GetPosition(row, column);
        }
        public string GetPosition(int rank, int file)
        {
            return $"{(char)(file + Constants.ASCIIcodePrefix)}{rank}";
        }

        /// <summary>
        /// Move up one step
        /// </summary>
        public void MoveUp()
        {
            if (IsWithinBounds(row + 1, column))
                row++;
        }

        /// <summary>
        /// Move down one step
        /// </summary>
        public void MoveDown()
        {
            if (IsWithinBounds(row - 1, column))
                row--;
        }

        public void MoveLeft()
        {
            if (IsWithinBounds(row, column - 1))
                column--;
        }

        public void MoveRight()
        {
            if (IsWithinBounds(row, column + 1))
                column++;
        }
    }
}
