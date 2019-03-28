namespace Caldast.OODesignProblems.TicTacToe.Model.BoardMembers
{
    public class Board
    {
        private Symbol[,] _board;

        /// <summary>
        /// Gets size of board
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size"></param>
        public Board(int size)
        {
            _board = new Symbol[size, size];
            Size = size;
            InitializeBoard();
        }

        /// <summary>
        /// Initialize board to none
        /// </summary>
        private void InitializeBoard()
        {
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    _board[r, c] = Symbol.None;
                }
            }
        }

        /// <summary>
        /// Sets cell value with symbol
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="s"></param>
        public void SetCell(int r, int c, Symbol s)
        {
            _board[r, c] = s;
        }

        /// <summary>
        /// Gets cell value
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public Symbol GetCell(int r, int c)
        {
            return _board[r, c];
        }

        /// <summary>
        /// Gets board 
        /// </summary>
        /// <returns></returns>
        public Symbol[,] GetBoard()
        {
            return _board;
        }

    }
}
