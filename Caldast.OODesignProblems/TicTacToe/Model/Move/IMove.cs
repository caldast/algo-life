using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using System;

namespace Caldast.OODesignProblems.TicTacToe.Model.Move
{
    /// <summary>
    /// Represents contract for move
    /// </summary>
    public interface IMove
    {
        Cell GetMove();
        Cell GetLastMove();
        void SetMove(int r, int c);
        Symbol Symbol { get; }
    }

    public abstract class Move: IMove
    {
        protected Board board;
        protected Move(Board b)
        {
            board = b;
        }
        public abstract Cell GetMove();

        public abstract Cell GetLastMove();

        public void SetMove(int r, int c)
        {
            // validate move, can only set if cell is empty
            if (r >= board.Size || c >= board.Size 
                || board.GetCell(r, c) != Symbol.None)
            {
                throw new InvalidOperationException(Constant.Constants.InvalidCell);                
            }

            // template method to be overridden by concrete class
            SetMoveOperation(r, c);
        }

        protected abstract void SetMoveOperation(int r, int c);
        public virtual Symbol Symbol { get; protected set; }
    }
}
