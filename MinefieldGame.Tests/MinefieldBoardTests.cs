using MinefieldGame.Domain;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MinefieldGame.Tests
{
    using MinefieldGame.Helpers;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class MinefieldBoardTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public void Constructor_WithValidNumberOfMines_ShouldInitializeBoard(int numberOfMines)
        {
            // Arrange

            // Act
            var minefieldBoard = new MinefieldBoard(numberOfMines);

            // Assert
            Assert.NotNull(minefieldBoard);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(65)]
        [InlineData(100)]
        public void Constructor_WithInvalidNumberOfMines_ShouldThrowArgumentOutOfRangeException(int numberOfMines)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MinefieldBoard(numberOfMines));
        }

        [Fact]
        public void IsEndPosition_WhenColumnEqualsBoardSize_ShouldReturnTrue()
        {
            // Arrange
            var minefieldBoard = new MinefieldBoard(1);

            // Act
            // Move to the last column
            for (int i = 1; i < minefieldBoard.Size; i++)
            {
                minefieldBoard.MoveRight();
            }
            var isEndPosition = minefieldBoard.IsEndPosition;

            // Assert
            Assert.True(isEndPosition);
        }

        [Fact]
        public void IsEndPosition_WhenColumnNotEqualsBoardSize_ShouldReturnFalse()
        {
            // Arrange
            var minefieldBoard = new MinefieldBoard(1);

            // Act
            var isEndPosition = minefieldBoard.IsEndPosition;

            // Assert
            Assert.False(isEndPosition);
        }

        [Fact]
        public void Mines_WhenInitialized_ShouldContainNumberOfMinesSpecified()
        {
            // Arrange
            var numberOfMines = 5;

            // Act
            var minefieldBoard = new MinefieldBoard(numberOfMines);

            // Assert
            Assert.Equal(numberOfMines, minefieldBoard.Mines.Count);
        }

        [Fact]
        public void IsMine_WhenPositionContainsMine_ShouldReturnTrueAndRemoveMine()
        {
            // Arrange
            var numberOfMines = 1;
            var minefieldBoard = new MinefieldBoard(numberOfMines);
            var minePosition = minefieldBoard.Mines[0];

            // Act
            var isMine = minefieldBoard.IsMine(minePosition);

            // Assert
            Assert.True(isMine);
            Assert.DoesNotContain(minePosition, minefieldBoard.Mines);
        }

        [Fact]
        public void IsMine_WhenPositionDoesNotContainMine_ShouldReturnFalse()
        {
            // Arrange
            var minefieldBoard = new MinefieldBoard(1);
            var positionWithoutMine = minefieldBoard.CurrentPosition();

            // Act
            var isMine = minefieldBoard.IsMine(positionWithoutMine);

            // Assert
            Assert.False(isMine);
        }

        [Fact]
        public void GenerateRandomMinePositions_WithValidQuantity_ShouldReturnListOfSpecifiedQuantity()
        {
            // Arrange
            var minefieldBoard = new MinefieldBoard(1);
            var quantity = 3;

            // Act
            var minePositions = minefieldBoard.GenerateRandomMinePositions(quantity);

            // Assert
            Assert.Equal(quantity, minePositions.Count);
        }
    }

}
