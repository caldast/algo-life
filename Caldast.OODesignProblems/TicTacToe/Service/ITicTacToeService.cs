using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using Caldast.OODesignProblems.TicTacToe.Model.Player;

namespace Caldast.OODesignProblems.TicTacToe.Service
{
    /// <summary>
    /// Represents contract for TicTacToe Service
    /// </summary>
    public interface ITicTacToeService
    {
        void SetPlayer1(Player player1);
        void SetPlayer2(Player player2);
        Board Board { get; }
        Player CurrentPlayer { get; }
        bool HasWon();
        Player Winner { get; }
        bool IsGameOver();
        void SetCurrentPlayer(Player player);
        void TogglePlayer();
        void Save();
        void Load();
    }
}
