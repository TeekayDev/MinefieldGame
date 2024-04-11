using MinefieldGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Core
{

    public class GameEngine : IGameEngine
    {
        private readonly Board board;
        private readonly Player player;
        private readonly Mine mine;
        private readonly OutputManager outputManager;

        public GameEngine(Board board, Player player, Mine mine, OutputManager outputManager)
        {
            this.board = board;
            this.player = player;
            this.mine = mine;
            this.outputManager = outputManager;
        }

        public void Run()
        {
            int rankLabel = new Random().Next(1, board.Size);
            int filePosition = 1;
            string posName = PositionName(rankLabel, filePosition);

            outputManager.DisplayMessage("Press arrow keys to move (Press 'q' to quit):");
            outputManager.DisplayMessage($"You are currently at position: {posName}");

            while (player.LivesRemaining > 0 && filePosition < board.Size)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                player.IncrementMoves();

                if (keyInfo.Key == ConsoleKey.UpArrow && board.IsWithinBounds(rankLabel + 1, filePosition))
                    rankLabel++;
                else if (keyInfo.Key == ConsoleKey.DownArrow && board.IsWithinBounds(rankLabel - 1, filePosition))
                    rankLabel--;
                else if (keyInfo.Key == ConsoleKey.LeftArrow && board.IsWithinBounds(rankLabel, filePosition - 1))
                    filePosition--;
                else if (keyInfo.Key == ConsoleKey.RightArrow && board.IsWithinBounds(rankLabel, filePosition + 1))
                    filePosition++;
                else if (keyInfo.Key == ConsoleKey.Q)
                {
                    outputManager.DisplayMessage("Exiting...");
                    break;
                }

                bool mineHit = CheckMineHit(posName);
                outputManager.DisplayPosition(posName, player.LivesRemaining, player.TotalMovesTaken, mineHit);
            }

            DisplayFinalScore(filePosition);
        }

        private bool CheckMineHit(string newPosition)
        {
            if (mine.IsMine(newPosition))
            {
                player.DecrementLives();
                return true;
            }
            return false;
        }

        private string PositionName(int rankLabel, int filePosition)
        {
            return $"{((char)(filePosition + 96)).ToString().ToUpper()}{rankLabel}";
        }

        private void DisplayFinalScore(int filePosition)
        {
            if (player.LivesRemaining > 0 && filePosition == board.Size)
            {
                outputManager.DisplayMessage($"Congratulations! Final score is Number of moves taken: {player.TotalMovesTaken}");
            }
            else
            {
                outputManager.DisplayMessage($"Sorry, you did not reach the other side of the board.");
            }
        }
    }
}
