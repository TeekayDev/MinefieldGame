using MinefieldGame.Domain;

namespace MinefieldGame.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void LivesRemaining_Returns_Correct_Value()
        {
            // Arrange
            int initialLives = 3;
            var player = new Player(initialLives);

            // Act & Assert
            Assert.Equal(initialLives, player.LivesRemaining);
        }

        [Fact]
        public void TotalMovesTaken_Returns_Correct_Value()
        {
            // Arrange
            int initialLives = 3;
            var player = new Player(initialLives);

            // Act & Assert
            Assert.Equal(0, player.TotalMovesTaken);
        }

        [Fact]
        public void DecrementLives_Decreases_Lives_Remaining()
        {
            // Arrange
            var player = new Player(3);

            // Act
            player.DecrementLives();

            // Assert
            Assert.Equal(2, player.LivesRemaining);
        }

        [Fact]
        public void IncrementMoves_Increases_Total_Moves_Taken()
        {
            // Arrange
            var player = new Player(3);

            // Act
            player.IncrementMoves();
            player.IncrementMoves();

            // Assert
            Assert.Equal(2, player.TotalMovesTaken);
        }
    }

}
