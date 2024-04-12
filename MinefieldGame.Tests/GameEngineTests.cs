using MinefieldGame.Core;
using MinefieldGame.Domain;
using Xunit;

namespace MinefieldGame.Tests
{
    public class GameEngineTests
    {
        [Fact]
        public void Board_IsWithinBounds_ReturnsTrue()
        {
            // Arrange
            var board = new Board();

            // Act & Assert
            Assert.True(board.IsWithinBounds(1, 1));
            Assert.True(board.IsWithinBounds(8, 8));
            Assert.True(board.IsWithinBounds(4, 4));
        }

        [Fact]
        public void Board_IsWithinBounds_ReturnsFalse()
        {
            // Arrange
            var board = new Board();

            // Act & Assert
            Assert.False(board.IsWithinBounds(0, 1));
            Assert.False(board.IsWithinBounds(1, 9));
            Assert.False(board.IsWithinBounds(9, 8));
        }

        [Fact]
        public void Player_DecrementLives_DecreasesLives()
        {
            // Arrange
            var player = new Player(3);

            // Act
            player.DecrementLives();

            // Assert
            Assert.Equal(2, player.LivesRemaining);
        }

        [Fact]
        public void Player_IncrementMoves_IncreasesMoves()
        {
            // Arrange
            var player = new Player(3);

            // Act
            player.IncrementMoves();
            player.IncrementMoves();

            // Assert
            Assert.Equal(2, player.TotalMovesTaken);
        }

        //[Fact]
        //public void Mine_IsMine_ReturnsTrue()
        //{
        //    // Arrange
        //    var mine = new Mine(3);

        //    // Act & Assert
        //    Assert.True(mine.IsMine("E6"));
        //    Assert.True(mine.IsMine("B1"));
        //    Assert.True(mine.IsMine("C4"));
        //}

        //[Fact]
        //public void Mine_IsMine_ReturnsFalse()
        //{
        //    // Arrange
        //    var mine = new Mine(4);

        //    // Act & Assert
        //    Assert.False(mine.IsMine("A1"));
        //    Assert.False(mine.IsMine("D5"));
        //    Assert.False(mine.IsMine("H8"));
        //}

        //[Fact]
        //public void GameEngine_PlayerMovesToMine_DecrementsLives()
        //{
        //    // Arrange
        //    var gameEngine = new GameEngine(8, 3, new string[] { "E6", "B1", "C4" });

        //    // Act
        //    gameEngine.CheckMineHit(6, 5);

        //    // Assert
        //    Assert.Equal(2, gameEngine.player.LivesRemaining);
        //}

        //[Fact]
        //public void GameEngine_PlayerMovesToNonMine_DoesNotDecrementLives()
        //{
        //    // Arrange
        //    var gameEngine = new GameEngine(8, 3, new string[] { "E6", "B1", "C4" });

        //    // Act
        //    gameEngine.CheckMineHit(5, 5);

        //    // Assert
        //    Assert.Equal(3, gameEngine.player.LivesRemaining);
        //}
    }

}