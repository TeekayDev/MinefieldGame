using MinefieldGame.Domain;

namespace MinefieldGame.Core
{
    using MinefieldGame.Interfaces;
    using System;

    /// <summary>
    /// Represents the game engine controlling player movements and game state.
    /// </summary>
    public class GameEngine : IGameEngine
    {
        private readonly Player _player;
        private readonly MinefieldBoard _board;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
        /// <param name="board">The minefield board.</param>
        /// <param name="player">The player.</param>
        public GameEngine(MinefieldBoard board, Player player)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        /// <summary>
        /// Gets a value indicating whether the game is still in play.
        /// </summary>
        public bool StillInPlay => _player.LivesRemaining > 0 && !_board.IsEndPosition;

        /// <summary>
        /// Moves the player based on the input key.
        /// </summary>
        /// <param name="keyInfo">The input key.</param>
        public void Move(ConsoleKeyInfo keyInfo)
        {
            var previousPosition = _board.CurrentPosition();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    _board.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    _board.MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                    _board.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    _board.MoveRight();
                    break;
                case ConsoleKey.Q:
                    break;
            }

            if (!previousPosition.Equals(_board.CurrentPosition()))
            {
                _player.IncrementMoves();
            }
        }

        /// <summary>
        /// Gets the current position of the player.
        /// </summary>
        public string CurrentPosition => _board.CurrentPosition();

        /// <summary>
        /// Gets a value indicating whether the player has hit a mine.
        /// </summary>
        public bool IsMineHit => CheckMineHit(_board.CurrentPosition());

        /// <summary>
        /// Gets the remaining lives of the player.
        /// </summary>
        public int LivesRemaining => _player.LivesRemaining;

        /// <summary>
        /// Gets the total number of moves taken by the player.
        /// </summary>
        public int TotalMovesTaken => _player.TotalMovesTaken;

        /// <summary>
        /// Gets a value indicating whether the game is completed.
        /// </summary>
        public bool Completed => _player.LivesRemaining > 0 && _board.IsEndPosition;

        /// <summary>
        /// Checks if the resulting new position contains a mine.
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns>True if the position contains a mine, otherwise false.</returns>
        private bool CheckMineHit(string position)
        {
            if (_board.IsMine(position))
            {
                _player.DecrementLives();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the player input is valid.
        /// </summary>
        /// <param name="keyInfo">The input key.</param>
        /// <returns>True if the game is still in play, otherwise false.</returns>
        public bool PlayerInput(ConsoleKeyInfo keyInfo)
        {
            return StillInPlay;
        }
    }


}
