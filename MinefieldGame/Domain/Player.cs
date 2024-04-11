using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class Player : IPlayer
    {
        private int totalLives;
        private int totalMoves;

        public Player(int initialLives)
        {
            totalLives = initialLives;
            totalMoves = 0;
        }

        public int LivesRemaining => totalLives;
        public int TotalMovesTaken => totalMoves;
        public void DecrementLives()
        {
            totalLives--;
        }

        public void IncrementMoves()
        {
            totalMoves++;
        }
    }
}
