using MinefieldGame.Domain;

namespace MinefieldGame.Tests
{
    public class MineTests
    {
        [Fact]
        public void Quantity_Returns_Correct_Value()
        {
            // Arrange
            int quantity = 5;
            var mine = new Mine(quantity);

            // Act
            int result = mine.Quantity;

            // Assert
            Assert.Equal(quantity, result);
        }

        [Fact]
        public void Positions_Can_Be_Set_And_Retrieved()
        {
            //// Arrange
            //string[] positions = { "A1", "B2", "C3" };
            //var mine = new Mine(3);

            //// Act
            //mine.Positions = positions;
            //string[] result = mine.Positions;

            //// Assert
            //Assert.Equal(positions, result);
        }

        [Fact]
        public void IsMine_Returns_True_If_Position_Is_A_Mine()
        {
            //// Arrange
            //string[] positions = { "A1", "B2", "C3" };
            //var mine = new Mine(positions.Length);
            //mine.Positions = positions;

            //// Act & Assert
            //foreach (string position in positions)
            //{
            //    Assert.True(mine.IsMine(position));
            //}
        }

        [Fact]
        public void IsMine_Returns_False_If_Position_Is_Not_A_Mine()
        {
            //// Arrange
            //string[] positions = { "A1", "B2", "C3" };
            //var mine = new Mine(positions.Length);
            //mine.Positions = positions;

            //// Act & Assert
            //Assert.False(mine.IsMine("D4"));
            //Assert.False(mine.IsMine("A2"));
        }
    }

}
