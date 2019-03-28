using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
namespace Caldast.OODesignProblems.TicTacToe.Model.Move
{
    /// <summary>
    /// Represents move performed by human
    /// </summary>
    public sealed class HumanMove : Move
    {
        private int _row;
        private int _col;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="board"></param>
        public HumanMove(Board board, Symbol s) : base(board)
        {
            Symbol = s;
        }        

        /// <summary>
        /// Get last move
        /// </summary>
        /// <returns></returns>
        public override Cell GetLastMove()
        {
            return GetMove();
        }

        /// <summary>
        /// Gets move done by human
        /// </summary>
        /// <returns></returns>
        public override Cell GetMove()
        {
            return new Cell(_row, _col);
        }

        /// <summary>
        /// Sets move done by human
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        protected override void SetMoveOperation(int r, int c)
        {
            _row = r;
            _col = c;
            board.SetCell(r, c, this.Symbol);
        }
    }
}
