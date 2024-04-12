using MinefieldGame.Helpers;
using MinefieldGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;


namespace MinefieldGame.Domain
{
    public class ChessBoardForMineSweeper : Board, IChessBoardForMineSweeper
    {
        private readonly Mine _mine;

        public ChessBoardForMineSweeper(Mine mine)
        {
            // Generate a random position on the left side of the board.
            column = 1;
            row = new Random().Next(1, Size);

            // Generate other a random position for mines.
            _mine = mine;
            _mine.Positions = GenerateRandomMinePosition(mine.Quantity);
        }

        public Mine Mines { get { return _mine; } }

        public bool IsEndPosition { get { return column == _boardSize; } }


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
                string newNo = string.Empty;
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
