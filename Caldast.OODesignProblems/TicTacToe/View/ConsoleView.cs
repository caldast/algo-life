using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using System;

namespace Caldast.OODesignProblems.TicTacToe.View
{
    /// <summary>
    /// View class to display information to console
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// Displays message to console
        /// </summary>
        /// <param name="message"></param>
        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Gets input row and col values from console
        /// </summary>
        /// <returns></returns>
        public Cell GetRowCol()
        {
            Console.WriteLine("Enter Row:");

            int r = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Col:");

            int c = int.Parse(Console.ReadLine());

            return new Cell(r, c);
        }

        /// <summary>
        /// Display board to user
        /// </summary>
        /// <param name="board"></param>
        public void DisplayBoard(Symbol[,] board)
        {
            int len = board.GetLength(0);

            for (int r = 0; r < len; r++)
            {
                for (int c = 0; c < len; c++)
                {
                    Symbol type = (Symbol) board[r, c];
                    switch (type)
                    {
                        case Symbol.None:
                            Console.Write(" * ");
                            break;
                        case Symbol.Zero:
                            Console.Write(" O ");
                            break;
                        case Symbol.Cross:
                            Console.Write(" X ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
