using Caldast.OODesignProblems.TicTacToe.Constant;
using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using System;

namespace Caldast.OODesignProblems.TicTacToe.Model.Move
{
    /// <summary>
    /// Represents move class for machine
    /// </summary>
    public class MachineMove : Move
    {      
        private int _row;
        private int _col;

        public MachineMove(Board board, Symbol s) 
            : base(board)
        {
            Symbol = s;
        }       

        public override Cell GetLastMove()
        {
            return new Cell(_row,_col);
        }

        /// <summary>
        /// Gets move performed by machine, tries upt
        /// </summary>
        /// <returns></returns>
        public override Cell GetMove()
        {         

            var random = new Random();
            Cell m = new Cell(random.Next(0, board.Size),
                random.Next(0, board.Size));

            int counter = 0;

            // tries make sure that it doesn't go in infinite loop
            while (counter < Constants.NoOfTriesForRandomNumberGenerator)
            {
                if (board.GetCell(m.Row, m.Col) == Symbol.None)
                {                   
                    return m;
                }
                m = new Cell(random.Next(0, board.Size),
                random.Next(0, board.Size));

                counter++;
            }

            throw new Exception("Cannot find the cell in the range");
        }

        /// <summary>
        /// Sets move done by machine
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
