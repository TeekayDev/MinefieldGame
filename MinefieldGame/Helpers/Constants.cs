using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Helpers
{
    /// <summary>
    /// This constants could alternatively (are idealy) supplied via a config file.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The size of the board (number of squares required for one side)
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

        /// <summary>
        /// ASCII code base before upper case alphabets starts
        /// </summary>
        public static int ASCIIcodePrefix = 64;
    }
}
