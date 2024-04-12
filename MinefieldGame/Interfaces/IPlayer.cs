namespace MinefieldGame.Interfaces
{
    public interface IPlayer
    {
        int LivesRemaining { get; }
        int TotalMovesTaken { get; }

        void DecrementLives();
        void IncrementMoves();
    }
}