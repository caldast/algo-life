using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using Caldast.OODesignProblems.TicTacToe.Model.Move;

namespace Caldast.OODesignProblems.TicTacToe.Model.Player
{
    /// <summary>
    /// Represents player object
    /// </summary>
    public abstract class Player
    {
        public virtual IMove Move { get; set; }

        /// <summary>
        /// Sets move performed by <see ref="Player"/>
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public virtual void SetMove(int r, int c)
        {
            Move.SetMove(r, c);
        }

        /// <summary>
        /// Gets move performed by <see ref="Player"/>
        /// </summary>
        /// <returns></returns>
        public virtual Cell GetMove()
        {
            return Move.GetMove();
        }

        /// <summary>
        /// Last move performed by the user
        /// </summary>
        /// <returns></returns>
        public virtual Cell GetLastMove()
        {
            return Move.GetLastMove();
        }

        /// <summary>
        /// Symbol
        /// </summary>
        public virtual Symbol Symbol { get; protected set; }
    } 

   

}
