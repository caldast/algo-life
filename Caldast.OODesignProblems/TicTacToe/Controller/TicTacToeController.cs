using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using Caldast.OODesignProblems.TicTacToe.Model.Player;
using Caldast.OODesignProblems.TicTacToe.Service;
using Caldast.OODesignProblems.TicTacToe.View;
using Caldast.OODesignProblems.TicTacToe.Constant;
using System;

namespace Caldast.OODesignProblems.TicTacToe.Controller
{

    public class TicTacToeController
    {
        private readonly ITicTacToeService _ticTacToeService;
        private readonly IView _view;

        public TicTacToeController(ITicTacToeService ticTacToeService, IView view)
        {
            _ticTacToeService = ticTacToeService;
            _view = view;
        }

        /// <summary>
        /// Set player 1
        /// </summary>
        /// <param name="player1"></param>
        public void SetPlayer1(Player player1)
        {
            _ticTacToeService.SetPlayer1(player1);
        }

        /// <summary>
        /// Set player 2
        /// </summary>
        /// <param name="player2"></param>
        public void SetPlayer2(Player player2)
        {
            _ticTacToeService.SetPlayer2(player2);
        }

        /// <summary>
        /// Set player
        /// </summary>
        /// <param name="player"></param>
        public void SetCurrentPlayer(Player player)
        {
            _ticTacToeService.SetCurrentPlayer(player);
        }

        /// <summary>
        /// Play the game
        /// </summary>
        public void Play()
        {
            while (true)
            {
                Player currentPlayer = _ticTacToeService.CurrentPlayer;

                if (currentPlayer is HumanPlayer)
                {
                    Cell input = _view.GetRowCol();
                    try
                    {
                        currentPlayer.SetMove(input.Row, input.Col);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                else
                {
                    Cell move = currentPlayer.GetMove();
                    currentPlayer.SetMove(move.Row, move.Col);

                    _view.Display(string.Format(Constants.PlayerMoveMessage,
                        currentPlayer.Symbol,move.Row,move.Col));
                }

                if (_ticTacToeService.HasWon() || _ticTacToeService.IsGameOver())
                    break;

                _ticTacToeService.TogglePlayer();
            };

            if (_ticTacToeService.Winner != null)
            {
                _view.Display(string.Format(Constants.WinMessage,_ticTacToeService.Winner.Symbol));
               
            }
            else if (_ticTacToeService.IsGameOver())
            {
                _view.Display(Constants.GameOverMessage);
            }            
        }

        /// <summary>
        /// Display board on the UI
        /// </summary>
        public void DisplayBoard()
        {
            Symbol[,] board = _ticTacToeService.Board.GetBoard();
            _view.DisplayBoard(board);
        }     

    }

   

  

   

   



}
