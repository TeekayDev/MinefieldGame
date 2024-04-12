using MinefieldGame.Core;
using MinefieldGame.Domain;
using MinefieldGame.Helpers;
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
            /// could be stored and read from an app settings file
            /// or passed in as input paramerets.
            try
            {
                var outputManager = new OutputManager();
                var player = new Player(Constants.NumberOfLives);
                var board = new ChessBoardForMineSweeper(Constants.NumberOfMines);

                var gameEngine = new GameEngine(board, player, outputManager);
                gameEngine.Run();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
