using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Domain
{
    /// <summary>
    /// This constants could alternatively (are idealy) supplied via a config file.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The size of the board (number of squares required on one side)
        /// </summary>
        public static int BoardSize = 8;

        /// <summary>
        /// The number of lives 
        /// </summary>
        public static int NumberOfLives = 3;

        /// <summary>
        /// Number Of Mines wanted
        /// </summary>
        public static int NumberOfMines = 4;
    }
}
