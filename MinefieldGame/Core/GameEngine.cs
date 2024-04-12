using MinefieldGame.Domain;
using MinefieldGame.Helpers;
using MinefieldGame.Interfaces;
using System;


namespace MinefieldGame.Core
{

    /// <summary>
    /// This is the core of the application which runs the game
    /// </summary>
    public class GameEngine : IGameEngine
    {
        private readonly Player player;
        private readonly OutputManager outputManager;
        private readonly ChessBoardForMineSweeper board;        

        public GameEngine(ChessBoardForMineSweeper board, Player player, OutputManager outputManager)
        {
            this.board = board;
            this.player = player;
            this.outputManager = outputManager;
        }

        /// <summary>
        /// Run the game engine
        /// </summary>
        public void Run()
        {
            DisplayInstructions(board.CurrentPosition());

            while (player.LivesRemaining > 0 && !board.IsEndPosition)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                if (UpdateBoardPosition(keyInfo))
                    player.IncrementMoves();

                DisplayCurrentStatus();
            }
            
            DisplayFinalScore();
        }

        /// <summary>
        /// Sends the selected input key to the board for updating
        /// </summary>
        /// <param name="keyInfo"></param>
        private bool UpdateBoardPosition(ConsoleKeyInfo keyInfo)
        {
            // A factory approach would be more ideal for expansion
            // this is a quick implementation due to time constraints
            // and for simplicity of the requirement

            var previousPosition = board.CurrentPosition();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    board.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    board.MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    board.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    board.MoveRight();
                    break;
                case ConsoleKey.Q:
                    break;
            }

            return !previousPosition.Equals(board.CurrentPosition());
        }

        /// <summary>
        /// Display introductry instruction to the user.
        /// </summary>
        /// <param name="startingPositionName"></param>
        private void DisplayInstructions(string startingPositionName)
        {
            outputManager.DisplayMessage(Messages.GameInstructions);
            outputManager.DisplayMessage($"You are currently at position: {startingPositionName}");
        }

        /// <summary>
        /// Display the current in-play positions, lives remaining and moves so far taken.
        /// </summary>
        private void DisplayCurrentStatus()
        {
            var newposition = board.CurrentPosition();
            bool mineHit = CheckMineHit(newposition);
            outputManager.DisplayPosition(newposition, player.LivesRemaining, player.TotalMovesTaken, mineHit);
        }

        /// <summary>
        /// Check and track if the resulting new position contains a mine.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool CheckMineHit(string position)
        {
            if (board.IsMine(position))
            {
                player.DecrementLives();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Displays the end of game data and result.
        /// </summary>
        /// <param name="filePosition"></param>
        private void DisplayFinalScore()
        {
            outputManager.DisplayMessage(string.Empty);
            outputManager.DisplayMessage(string.Empty);

            if (player.LivesRemaining > 0 && board.IsEndPosition)
            {
                outputManager.DisplayMessage($"{Messages.OfCongratulations} {player.TotalMovesTaken}");
            }
            else
            {
                outputManager.DisplayMessage(Messages.OfCommiseration);
            }
            outputManager.DisplayMessage(string.Empty);
        }
    }
}
