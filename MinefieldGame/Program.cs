using MinefieldGame.Core;
using MinefieldGame.Domain;
using MinefieldGame.Helpers;
using MinefieldGame.Interfaces;
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
        static void Main()
        {
            /// Idealy or alternatively the parameters passed for number of mines and lives
            /// could be stored and read from an app settings file
            /// or passed in as input paramerets.
            try
            {
                var outputManager = new OutputManager();
                var player = new Player(Constants.NumberOfLives);
                var board = new MinefieldBoard(Constants.NumberOfMines);
                var gameEngine = new GameEngine(board, player);

                outputManager.DisplayMessage(Messages.GameInstructions);
                outputManager.DisplayMessage($"You are currently at position: {gameEngine.CurrentPosition}");

                while (gameEngine.StillInPlay)
                {
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)
                        break;

                    gameEngine.Move(keyInfo);
                    outputManager.DisplayPosition(
                        gameEngine.CurrentPosition, 
                        gameEngine.LivesRemaining, 
                        gameEngine.TotalMovesTaken, 
                        gameEngine.IsMineHit);
                }

                outputManager.DisplayMessage(string.Empty);
                outputManager.DisplayMessage(string.Empty);

                if (gameEngine.Completed)
                {
                    outputManager.DisplayMessage($"{Messages.OfCongratulations} {gameEngine.TotalMovesTaken}");
                }
                else
                {
                    outputManager.DisplayMessage(Messages.OfCommiseration);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
