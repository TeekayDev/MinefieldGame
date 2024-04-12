using MinefieldGame.Interfaces;


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
