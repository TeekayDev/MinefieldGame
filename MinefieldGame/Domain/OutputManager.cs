using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Core
{
    /// <summary>
    /// Displays _positions and generic messages to an screen
    /// </summary>
    public class OutputManager : IOutputManager
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayPosition(string positionName, int livesRemaining, int totalMovesTaken, bool mineHit)
        {
            string boom = mineHit ? " *Boom!*" : string.Empty;
            Console.WriteLine($"{positionName}  |  Lives Remaining:{livesRemaining}  |  Total Moves:{totalMovesTaken}.  {boom}");
        }
    }

}
