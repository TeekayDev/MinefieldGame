using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Domain
{
    public class Board : IBoard
    {
        public int Size { get { return Constants.BoardSize; } }

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
    }
}
