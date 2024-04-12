using MinefieldGame.Domain;

namespace MinefieldGame.Tests
{

    /// <summary>
    /// Performs unit tests on the methods of GameBoard class
    /// </summary>
    public class GameBoardTests
    {
        [Theory]
        [InlineData(2, 2, 3)]
        [InlineData(8, 2, 8)]
        public void MoveUp_Method_Increases_Row_When_Within_Bounds(int initialRow, int initialColumn, int expectedRow)
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(initialRow, initialColumn);

            // Act
            gameBoard.MoveUp();

            // Assert
            Assert.Equal(expectedRow, gameBoard.GetRow());
        }

        [Theory]
        [InlineData(8, 2)]
        [InlineData(8, 4)]
        public void MoveUp_Method_Does_Not_Increase_Row_When_Out_Of_Bounds(int initialRow, int initialColumn)
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(initialRow, initialColumn);

            // Act
            gameBoard.MoveUp();

            // Assert
            Assert.Equal(initialRow, gameBoard.GetRow());
        }

        [Theory]
        [InlineData(5, 2, 4)]
        [InlineData(1, 2, 1)]
        public void MoveDown_Method_Decreases_Row_When_Within_Bounds(int initialRow, int initialColumn, int expectedRow)
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(initialRow, initialColumn);

            // Act
            gameBoard.MoveDown();

            // Assert
            Assert.Equal(expectedRow, gameBoard.GetRow());
        }

        [Theory]
        [InlineData(3, 5, 4)]
        [InlineData(3, 1, 1)]
        public void MoveLeft_Method_Decreases_Column_When_Within_Bounds(int initialRow, int initialColumn, int expectedColumn)
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(initialRow, initialColumn);

            // Act
            gameBoard.MoveLeft();

            // Assert
            Assert.Equal(expectedColumn, gameBoard.GetColumn());
        }

        [Theory]
        [InlineData(3, 5, 6)]
        [InlineData(3, 8, 8)]
        public void MoveRight_Method_Increases_Column_When_Within_Bounds(int initialRow, int initialColumn, int expectedColumn)
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(initialRow, initialColumn);

            // Act
            gameBoard.MoveRight();

            // Assert
            Assert.Equal(expectedColumn, gameBoard.GetColumn());
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(8, 8, true)]
        [InlineData(4, 4, true)]
        [InlineData(0, 0, false)]
        [InlineData(9, 9, false)]
        [InlineData(0, 5, false)]
        [InlineData(5, 0, false)]
        public void IsWithinBounds_Method_Returns_Correct_Result(int newRow, int newColumn, bool expectedResult)
        {
            // Arrange
            var gameBoard = new TestGameBoard();

            // Act
            var result = gameBoard.IsWithinBounds(newRow, newColumn);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(4, 3, "C4")]
        [InlineData(6, 2, "B6")]
        public void CurrentPosition_Method_Returns_Correct_Position(int initialRow, int initialColumn, string expectedPosition)
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(initialRow, initialColumn);

            // Act
            var currentPosition = gameBoard.CurrentPosition();

            // Assert
            Assert.Equal(expectedPosition, currentPosition);
        }

        [Theory]
        [InlineData(2, 2, "B2")]
        [InlineData(7, 5, "E7")]
        public void GetPosition_Method_Returns_Correct_Position(int rank, int file, string expectedPosition)
        {
            // Arrange
            var gameBoard = new TestGameBoard();

            // Act
            var position = gameBoard.GetPosition(rank, file);

            // Assert
            Assert.Equal(expectedPosition, position);
        }

        [Fact]
        public void MoveDown_Method_Does_Not_Decrease_Row_When_Out_Of_Bounds()
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(1, 2); // Bottom _row

            // Act
            gameBoard.MoveDown();

            // Assert
            Assert.Equal(1, gameBoard.GetRow());
        }

        [Fact]
        public void MoveLeft_Method_Does_Not_Decrease_Column_When_Out_Of_Bounds()
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(3, 1); // Leftmost _column

            // Act
            gameBoard.MoveLeft();

            // Assert
            Assert.Equal(1, gameBoard.GetColumn());
        }

        [Fact]
        public void MoveRight_Method_Does_Not_Increase_Column_When_Out_Of_Bounds()
        {
            // Arrange
            var gameBoard = new TestGameBoard();
            gameBoard.SetPosition(3, 8); // Rightmost _column

            // Act
            gameBoard.MoveRight();

            // Assert
            Assert.Equal(8, gameBoard.GetColumn());
        }

    }


    /// <summary>
    /// The abstract class GameBoard cannot be instantiated directly
    /// </summary>
    public class TestGameBoard : GameBoard
    {
        public int GetRow() => _row;
        public int GetColumn() => _column;
        public void SetPosition(int newRow, int newColumn)
        {
            _row = newRow;
            _column = newColumn;
        }
    }
}
