
namespace board
{
    class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int rows, int columns)
        {
            return pieces[rows, columns];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.rows, pos.column];
        }

        public bool hasPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void addPiece(Piece p, Position pos)
        {
            if (hasPiece(pos))
            {
                throw new BoardException("Already exist a piece in this position!");
            }

            pieces[pos.rows, pos.column] = p;
            p.position = pos;
        }

        public bool validPosition (Position pos)
        {
            if(pos.rows < 0 || pos.rows >= rows ||  pos.column < 0 ||  pos.column >= columns)
            {
                return false;
            }

            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
