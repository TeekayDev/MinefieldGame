using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Domain
{
    public class Board : IBoard
    {
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
        public bool IsWithinBounds(int rankLabel, int filePosition)
        {
            return rankLabel >= 1 && rankLabel <= this.Size && filePosition >= 1 && filePosition <= this.Size;
        }

        /// <summary>
        /// Returns the position of the coordinate in chess board terminology 
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public string Position(int rank, int file)
        {
            return $"{((char)(file + 96)).ToString().ToUpper()}{rank}";

        }

        /// <summary>
        /// Generate a collection of random positions on the board
        /// avoiding the specidied number
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="avoidPosition"></param>
        /// <returns></returns>
        public string[] RandomPositions(int quantity, string avoidPosition)
        {
            string[] result = new string[quantity];

            for (int i = 0; i < quantity; i++)
            {
                string newNo = string.Empty;
                do
                {
                    newNo = Position(new Random().Next(1, Size), new Random().Next(1, Size));

                } while (newNo == avoidPosition || result.Contains(newNo));

                result[i] = newNo;
            }

            return result;

        }
    }
}
