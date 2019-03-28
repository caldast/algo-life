
using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using Caldast.OODesignProblems.TicTacToe.Model.Player;
using System;

namespace Caldast.OODesignProblems.TicTacToe.Service
{
    public class TicTacToeService: ITicTacToeService
    {
       
        private int _gameCounter = 0;
        private Player _player1;
        private Player _player2;
        private int _size => Board.Size;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="boardSize"></param>
        public TicTacToeService(int boardSize)
        {
            if (boardSize <= 0)
                throw new ArgumentException("input cannot be 0 or -ve");
            Board = new Board(boardSize);
        }

        /// <summary>
        /// Sets player 1
        /// </summary>
        /// <param name="player1"></param>
        public void SetPlayer1(Player player1)
        {
            _player1 = player1;
        }
        /// <summary>
        /// Sets player 2
        /// </summary>
        /// <param name="player2"></param>
        public void SetPlayer2(Player player2)
        {
            _player2 = player2;
        }

        /// <summary>
        /// Gets Board object.
        /// </summary>
        public Board Board { get; private set; }     
       
        /// <summary>
        /// Gets current player
        /// </summary>
        public Player CurrentPlayer { get; private set; }

        /// <summary>
        /// Gets winner player
        /// </summary>
        public Player Winner { get; private set; }

        /// <summary>
        /// Determines if a game is won
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            //TODO: MinMax algorithm can be used to determine score and win/loss scenario
            Cell cell = CurrentPlayer.GetLastMove();

            // check rows and col
            if (CheckRow(cell.Row) || CheckCol(cell.Col))
            {
                Winner = CurrentPlayer;
                return true;
            }

            // check diag left to right
            if (cell.Row == cell.Col && CheckDiag(1))
            {
                Winner = CurrentPlayer;
                return true;
            }

            // check diag right to left
            if (cell.Row == _size-1 -cell.Col && CheckDiag(-1))
            {
                Winner = CurrentPlayer;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a game is over
        /// </summary>
        /// <returns></returns>
        public bool IsGameOver()
        {
            return _gameCounter >= (_size * _size)-1;
        }

       /// <summary>
       /// Checks row to determine if a game is won
       /// </summary>
       /// <param name="row"></param>
       /// <returns></returns>
        private bool CheckRow(int row)
        {
            Symbol first = Board.GetCell(row,0);

            if (first == Symbol.None) return false;

            for (int c = 1; c < _size; c++)
            {
                if (first != Board.GetCell(row, c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks column to determine if a game is won
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool CheckCol(int col)
        {
            Symbol first = Board.GetCell(0,col);

            if (first == Symbol.None) return false;

            for (int r = 1; r < _size; r++)
            {
                if (first != Board.GetCell(r,col))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check diaglog to determine if a game is won
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private bool CheckDiag(int dir)
        {           
            int col = dir == 1 ? 0 : _size - 1;

            Symbol first = Board.GetCell(0, col);

            if (first == Symbol.None) return false;

            for (int r = 0; r < _size; r++)
            {
                if (first != Board.GetCell(r, col))
                    return false;
                col += dir;
            }
            return true;
        }
        
        /// <summary>
        /// Sets current player
        /// </summary>
        /// <param name="player"></param>
        public void SetCurrentPlayer(Player player)
        {
            CurrentPlayer = player;            
        }

        /// <summary>
        /// Switches player 
        /// </summary>
        public void TogglePlayer()
        {
            if (CurrentPlayer.Equals(_player1))
                SetCurrentPlayer(_player2);
            else
                SetCurrentPlayer(_player1);
            ++_gameCounter;
        }

        /// <summary>
        /// Saves game 
        /// </summary>
        public void Save()
        {
            // TODO: Save game state in db or file 
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Load previously saved game
        /// </summary>
        public void Load()
        {
            // TODO: Load game state from file or db
            throw new System.NotImplementedException();
        }
    }
}
