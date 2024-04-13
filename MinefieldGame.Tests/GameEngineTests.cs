using MinefieldGame.Core;
using MinefieldGame.Domain;
using MinefieldGame.Helpers;
using Moq;

namespace MinefieldGame.Tests
{
    public class GameEngineTests
    {
        [Fact]
        public void StillInPlay_Returns_True_When_PlayerLives_Remaining_And_NotAtEndPosition()
        {
            // Arrange
            var board = new MinefieldBoard(5);
            var player = new Player(3);
            var gameEngine = new GameEngine(board, player);

            // Act
            var result = gameEngine.StillInPlay;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Move_Increments_TotalMovesTaken_When_BoardPosition_Changes()
        {
            // Arrange
            var board = new MinefieldBoard(5);
            var player = new Player(3);
            var gameEngine = new GameEngine(board, player);

            // Act
            gameEngine.Move(new ConsoleKeyInfo('U', ConsoleKey.UpArrow, false, false, false));

            // Assert
            Assert.Equal(1, gameEngine.TotalMovesTaken);
        }

        [Fact]
        public void CurrentPosition_Returns_Current_Board_Position()
        {
            // Arrange
            var board = new MinefieldBoard(5);
            var player = new Player(3);
            var gameEngine = new GameEngine(board, player);

            // Act
            var result = gameEngine.CurrentPosition;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void LivesRemaining_Returns_Remaining_Lives()
        {
            // Arrange
            var board = new MinefieldBoard(5);
            var player = new Player(3);
            var gameEngine = new GameEngine(board, player);

            // Act
            var result = gameEngine.LivesRemaining;

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void TotalMovesTaken_Returns_Total_Moves()
        {
            // Arrange
            var board = new MinefieldBoard(5);
            var player = new Player(3);
            var gameEngine = new GameEngine(board, player);

            // Act
            gameEngine.Move(new ConsoleKeyInfo('U', ConsoleKey.RightArrow, false, false, false));
            gameEngine.Move(new ConsoleKeyInfo('U', ConsoleKey.RightArrow, false, false, false));
            gameEngine.Move(new ConsoleKeyInfo('U', ConsoleKey.RightArrow, false, false, false));
            var result = gameEngine.TotalMovesTaken;

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Completed_Returns_True_When_Player_Lives_Remaining_And_AtEndPosition()
        {
            // Arrange
            var board = new MinefieldBoard(1);
            var player = new Player(board.Size);
            var gameEngine = new GameEngine(board, player);

            // Act
            for (int i = 1; i < board.Size; i++)
            {
                gameEngine.Move(new ConsoleKeyInfo('U', ConsoleKey.RightArrow, false, false, false));
            }
            var result = gameEngine.Completed;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void PlayerInput_Returns_True_When_StillInPlay()
        {
            // Arrange
            var board = new MinefieldBoard(5);
            var player = new Player(3);
            var gameEngine = new GameEngine(board, player);

            // Act
            var result = gameEngine.PlayerInput(new ConsoleKeyInfo('a', ConsoleKey.A, false, false, false));

            // Assert
            Assert.True(result);
        }
    }
}