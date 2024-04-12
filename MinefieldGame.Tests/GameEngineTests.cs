using MinefieldGame.Core;
using MinefieldGame.Domain;
using MinefieldGame.Helpers;
using Moq;

namespace MinefieldGame.Tests
{
    public class GameEngineTests
    {
        private readonly Mock<ChessBoardForMineSweeper> mockBoard;
        private readonly Mock<Player> mockPlayer;
        private readonly Mock<OutputManager> mockOutputManager;

        public GameEngineTests()
        {
            mockBoard = new Mock<ChessBoardForMineSweeper>();
            mockPlayer = new Mock<Player>(3);
            mockOutputManager = new Mock<OutputManager>();
        }

        [Fact]
        public void Constructor_Initializes_GameEngine_With_Dependencies()
        {
            
        }
      
    }

}