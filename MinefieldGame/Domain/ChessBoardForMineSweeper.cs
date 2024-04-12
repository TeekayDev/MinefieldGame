using MinefieldGame.Helpers;
using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;


namespace MinefieldGame.Domain
{
    public class ChessBoardForMineSweeper : GameBoard
    {
        private readonly List<string> _minePositions;

        public ChessBoardForMineSweeper(int numberOfMines)
        {
            // Generate a random position on the left side of the board.
            _column = 1;
            _row = new Random().Next(1, Size);

            // Generate random position for mines.
            _minePositions = GenerateRandomMinePosition(numberOfMines);
        }       

        public bool IsEndPosition { get { return _column == _boardSize; } }

        public bool IsMine(string position)
        {
            if (_minePositions.Contains(position))
            {
                _minePositions.RemoveAt(_minePositions.IndexOf(position));
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Generate a collection of random positions on the board
        /// avoiding the specidied number
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="avoidPosition"></param>
        /// <returns></returns>
        public List<string> GenerateRandomMinePosition(int quantity)
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
