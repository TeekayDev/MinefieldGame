using Xunit;
using Moq;
using System;
using MinefieldGame.Domain;

namespace MinefieldGame.Tests
{
    public class ChessBoardForMineSweeperTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var mockMine = new Mock<Mine>(2);
            var chessBoard = new ChessBoardForMineSweeper(mockMine.Object);

            // Assert
            Assert.NotNull(chessBoard);
            Assert.NotNull(chessBoard.Mines);
        }

    }

}
