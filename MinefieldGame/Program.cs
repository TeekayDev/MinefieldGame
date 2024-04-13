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
            // The number of mines and lives could be stored and read from an app settings file.
            // A logger can be used to collect statistics on each game play.

            try
            {
                // Initialize required components for DI
                var outputManager = new OutputManager();
                var player = new Player(Constants.NumberOfLives);
                var board = new MinefieldBoard(Constants.NumberOfMines);
                
                // instantiate a new game session
                var gameEngine = new GameEngine(board, player);

                // Display game instructions and starting position of player
                outputManager.DisplayMessage(Messages.GameInstructions);
                outputManager.DisplayMessage($"You are currently at position: {gameEngine.CurrentPosition}");

                // Continue receiving user input until game completes or user cancels
                while (gameEngine.StillInPlay)
                {
                    // Read player input. Esc key received terminates the game
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)
                        break;

                    // Process the player's move
                    gameEngine.Move(keyInfo);

                    // Display updated game status
                    outputManager.DisplayPosition(
                        gameEngine.CurrentPosition,
                        gameEngine.LivesRemaining,
                        gameEngine.TotalMovesTaken,
                        gameEngine.IsMineHit);
                }

                // Display final game outcome
                outputManager.DisplayMessage(string.Empty);
                outputManager.DisplayMessage(string.Empty);

                if (gameEngine.Completed)
                {
                    // Player won
                    outputManager.DisplayMessage($"{Messages.OfCongratulations} {gameEngine.TotalMovesTaken}");
                }
                else
                {
                    // Player lost
                    outputManager.DisplayMessage(Messages.OfCommiseration);
                }
            }
            catch (Exception ex)
            {
                // Ideally a logger would be used to collect and store all exception details.
                Console.WriteLine("An unexpected error has occured. Please try close and resetart.");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
