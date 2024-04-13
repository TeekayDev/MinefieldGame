using System.Collections.Generic;

namespace MinefieldGame.Interfaces
{
    /// <summary>
    /// Defines the contract for a minefield game board.
    /// </summary>
    public interface IMinefieldBoard : IGameBoard
    {
        bool IsEndPosition { get; }

        bool IsMine(string position);

        List<string> GenerateRandomMinePositions(int quantity);
    }

}
