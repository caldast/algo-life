namespace Caldast.OODesignProblems.TicTacToe.Model.BoardMembers
{
    /// <summary>
    /// Cell determines the slot in board. 
    /// Represented by Row and Column
    /// </summary>
    public struct Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
