using MinefieldGame.Domain;

namespace MinefieldGame.Tests
{
    public class BoardTests
    {
        [Fact]
        public void IsWithinBounds_Returns_True_For_Valid_Position()
        {
            // Arrange
            var board = new TestBoard();

            // Act & Assert
            Assert.True(board.IsWithinBounds(1, 1)); // On the top-left corner
            Assert.True(board.IsWithinBounds(8, 8)); // On the bottom-right corner
            Assert.True(board.IsWithinBounds(4, 4)); // Somewhere in the middle
        }

        [Fact]
        public void IsWithinBounds_Returns_False_For_Invalid_Position()
        {
            // Arrange
            var board = new TestBoard();

            // Act & Assert
            Assert.False(board.IsWithinBounds(0, 0)); // Out of bounds (negative)
            Assert.False(board.IsWithinBounds(9, 9)); // Out of bounds (beyond board size)
            Assert.False(board.IsWithinBounds(0, 5)); // Out of bounds (rank < 1)
            Assert.False(board.IsWithinBounds(5, 0)); // Out of bounds (file < 1)
        }

        [Fact]
        public void GetPosition_Returns_Correct_Position_In_Chess_Terminology()
        {
            // Arrange
            var board = new TestBoard();

            // Act & Assert
            Assert.Equal("A1", board.GetPosition(1, 1));
            Assert.Equal("H8", board.GetPosition(8, 8));
            Assert.Equal("D5", board.GetPosition(5, 4));
        }

        [Fact]
        public void MoveUp_Decreases_Row_By_One_When_Within_Bounds()
        {
            
        }

        [Fact]
        public void MoveUp_Does_Not_Decrease_Row_When_Out_Of_Bounds()
        {
            
        }


    }

    public class TestBoard : Board
    {
        public int GetRow() => row;
        public int GetColumn() => column;
        public void SetPosition(int newRow, int newColumn)
        {
            row = newRow;
            column = newColumn;
        }
    }


}
