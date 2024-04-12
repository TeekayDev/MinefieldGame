using MinefieldGame.Core;
using MinefieldGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            /// Idealy or alternatively the parameters passed for number of mines and lives
            /// could be in the app settings.
            
            var board = new Board();
            var outputManager = new OutputManager();
            var mine = new Mine(Constants.NumberOfMines);
            var player = new Player(Constants.NumberOfLives);

            var gameEngine = new GameEngine(board, player, mine, outputManager);
            gameEngine.Run();
        }

    }
}
