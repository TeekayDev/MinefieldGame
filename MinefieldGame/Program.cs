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
            int initialLives = 3;
            string[] minePositions = { "E6", "B1", "C4" };

            var board = new Board();
            var player = new Player(initialLives);
            var mine = new Mine(minePositions);
            var outputManager = new OutputManager();

            var gameEngine = new GameEngine(board, player, mine, outputManager);
            gameEngine.Run();
        }

    }
}
