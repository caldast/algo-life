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
}
