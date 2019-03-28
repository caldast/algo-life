using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using Caldast.OODesignProblems.TicTacToe.Model.Move;

namespace Caldast.OODesignProblems.TicTacToe.Model.Player
{
    /// <summary>
    /// Class for Human Player
    /// </summary>
    public class HumanPlayer : Player
    {
        public HumanPlayer(Board _board, Symbol s)
        {
            Move = new HumanMove(_board, s);
            Symbol = s;
        }

    }
}
