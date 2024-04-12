namespace MinefieldGame.Interfaces
{
    /// <summary>
    /// Define the contract to be adhered to for GameBoard.
    /// </summary>
    public interface IGameBoard
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        bool IsWithinBounds(int newrow, int newcol);
        string CurrentPosition();
        string GetPosition(int rank, int file);
    }

}