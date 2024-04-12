using MinefieldGame.Domain;
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
    public static class Messages
    {
        /// <summary>
        /// The size of the board (number of squares required for one side)
        /// </summary>
        public static string GameInstructions = "Press arrow keys to move (Press 'q' to quit):";

        /// <summary>
        /// The number of lives 
        /// </summary>
        public static string OfCongratulations = "Congratulations! Final score is Number of moves taken: ";

        /// <summary>
        /// Number Of Mines wanted
        /// </summary>
        public static string OfCommiseration = "Sorry, you did not reach the other side of the board.";
    }
}
