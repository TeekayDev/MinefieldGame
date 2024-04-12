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
            
        }

        [Fact]
        public void IsMine_Returns_True_If_Position_Is_A_Mine()
        {
           
        }

        [Fact]
        public void IsMine_Returns_False_If_Position_Is_Not_A_Mine()
        {
           
        }
    }

}
