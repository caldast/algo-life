using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using Caldast.OODesignProblems.TicTacToe.Model.Move;

namespace Caldast.OODesignProblems.TicTacToe.Model.Player
{
    /// <summary>
    /// Class for Machine
    /// </summary>
    public class MachinePlayer : Player
    {       
        public MachinePlayer(Board _board, Symbol s)
        {
            Move = new MachineMove(_board,s);
            Symbol = s;
        }
    }
}
