using MinefieldGame.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace MinefieldGame.Domain
{
    using MinefieldGame.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a minefield game board.
    /// </summary>
    public class MinefieldBoard : GameBoard, IMinefieldBoard
    {
        private readonly List<string> _minePositions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinefieldBoard"/> class with the specified number of mines.
        /// </summary>
        /// <param name="numberOfMines">The number of mines to generate on the board.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of mines exceeds the available board space.</exception>
        public MinefieldBoard(int numberOfMines) : base(Constants.BoardSize)
        {
            if (numberOfMines < 1 ||
                numberOfMines >= ((_boardSize * _boardSize) - _boardSize))
                throw new ArgumentOutOfRangeException(nameof(numberOfMines),
                    "Number of mines requested exceeds available board space.");

            // Generate a random position on the left side of the board.
            _column = 1;
            _row = new Random().Next(1, Size);

            // Generate random positions for mines.
            _minePositions = GenerateRandomMinePositions(numberOfMines);
        }

        /// <summary>
        /// Gets a value indicating whether the current position is the end position of the board.
        /// </summary>
        public bool IsEndPosition => _column == _boardSize;

        /// <summary>
        /// Returns the list of currently available active mines.
        /// </summary>
        public List<string> Mines => _minePositions;

        /// <summary>
        /// Checks if the specified position contains a mine and removes it if found.
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns>True if the position contains a mine, otherwise false.</returns>
        public bool IsMine(string position)
        {
            if (_minePositions.Contains(position))
            {
                _minePositions.Remove(position);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Generates a collection of random positions on the board, avoiding the specified position.
        /// </summary>
        /// <param name="quantity">The number of random positions to generate.</param>
        /// <returns>A list of random positions.</returns>
        public List<string> GenerateRandomMinePositions(int quantity)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < quantity; i++)
            {
                string newNo;
                do
                {
                    newNo = GetPosition(new Random().Next(1, Size), new Random().Next(1, Size));

                } while (newNo == CurrentPosition() || result.Contains(newNo));

                result.Add(newNo);
            }

            return result;
        }
    }
}
