using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;

namespace Caldast.OODesignProblems.TicTacToe.View
{
    /// <summary>
    /// Represents contract for view
    /// </summary>
    public interface IView
    {
        Cell GetRowCol();
        void Display(string message);
        void DisplayBoard(Symbol[,] board);
    }
}
