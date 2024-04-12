using MinefieldGame.Domain;
using System.Collections.Generic;

namespace MinefieldGame.Interfaces
{
    public interface IChessBoardForMineSweeper
    {
        bool IsEndPosition { get; }

        Mine Mines { get; }

        List<string> GenerateRandomMinePosition(int quantity);
    }
}