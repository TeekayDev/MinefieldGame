using MinefieldGame.Core;
using MinefieldGame.Domain;

namespace MinefieldGame.Tests
{
    public class OutputManagerTests : IDisposable
    {
        private readonly StringWriter consoleOutput;
        private readonly TextWriter originalOutput;

        public OutputManagerTests()
        {
            consoleOutput = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(consoleOutput);
        }

        [Fact]
        public void DisplayMessage_Displays_Correct_Message()
        {
            // Arrange
            var outputManager = new OutputManager();
            string message = "Schneider Electric is the best :)";

            // Act
            outputManager.DisplayMessage(message);

            // Assert
            Assert.Contains(message, consoleOutput.ToString());
        }

        [Theory]
        [InlineData("A1", 2, 5, false, "A1  |  Lives Remaining: 2  |  Total Moves: 5.")]
        [InlineData("B2", 1, 8, true, "B2  |  Lives Remaining: 1  |  Total Moves: 8.   *Boom!*")]
        public void DisplayPosition_Displays_Correct_Format(string positionName, int livesRemaining, int totalMovesTaken, bool mineHit, string expectedOutput)
        {
            // Arrange
            var outputManager = new OutputManager();

            // Act
            outputManager.DisplayPosition(positionName, livesRemaining, totalMovesTaken, mineHit);

            // Assert
            Assert.Contains(expectedOutput, consoleOutput.ToString());
        }

        public void Dispose()
        {
            consoleOutput.Dispose();
            Console.SetOut(originalOutput);
        }
    }

}
