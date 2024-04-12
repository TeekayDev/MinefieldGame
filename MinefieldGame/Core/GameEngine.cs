using MinefieldGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinefieldGame.Core
{

    /// <summary>
    /// This is the core of the application which runs the game
    /// </summary>
    public class GameEngine : IGameEngine
    {
        private int row;
        private int column;

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
            column = 1;
            row = new Random().Next(1, board.Size);
            string startingPositionName = board.Position(row, column);

            mine.Positions = board.RandomPositions(3, startingPositionName);
            DisplayInstructions(startingPositionName);

            while (player.LivesRemaining > 0 && column < board.Size)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                player.IncrementMoves();

                if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
                else
                {
                    UpdatePosition(keyInfo);
                }

                DisplayCurrentStatus();
            }

            DisplayFinalScore(column);
        }

        private void DisplayInstructions(string startingPositionName)
        {
            outputManager.DisplayMessage("Press arrow keys to move (Press 'q' to quit):");
            outputManager.DisplayMessage($"You are currently at position: {startingPositionName}");
        }

        private void DisplayCurrentStatus()
        {
            var newposition = board.Position(row, column);
            bool mineHit = CheckMineHit(newposition);
            outputManager.DisplayPosition(newposition, player.LivesRemaining, player.TotalMovesTaken, mineHit);
        }

        private void UpdatePosition(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (board.IsWithinBounds(row + 1, column))
                        row++;
                    break;
                case ConsoleKey.DownArrow:
                    if (board.IsWithinBounds(row - 1, column))
                        row--;
                    break;
                case ConsoleKey.LeftArrow:
                    if (board.IsWithinBounds(row, column - 1))
                        column--;
                    break;
                case ConsoleKey.RightArrow:
                    if (board.IsWithinBounds(row, column + 1))
                        column++;
                    break;
            }
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

        private void DisplayFinalScore(int filePosition)
        {
            outputManager.DisplayMessage("");
            outputManager.DisplayMessage("");

            if (player.LivesRemaining > 0 && filePosition == board.Size)
            {
                outputManager.DisplayMessage($"Congratulations! Final score is Number of moves taken: {player.TotalMovesTaken}");
            }
            else
            {
                outputManager.DisplayMessage($"Sorry, you did not reach the other side of the board.");
            }
            outputManager.DisplayMessage("");

        }
    }
}
