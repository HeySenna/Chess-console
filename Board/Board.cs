
namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece Piece(int rows, int columns)
        {
            return Pieces[rows, columns];
        }

        public Piece Piece(Position pos)
        {
            return Pieces[pos.Rows, pos.Column];
        }

        public bool HasPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void AddPiece(Piece p, Position pos)
        {
            if (HasPiece(pos))
            {
                throw new BoardException("Already exist a piece in this position!");
            }

            Pieces[pos.Rows, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(Piece(pos) == null)
            {
                return null;
            }
            
            Piece aux = Piece(pos);
            aux.Position = null;
            Pieces[pos.Rows, pos.Column] = null;
            return aux;

        }

        public bool validPosition (Position pos)
        {
            if(pos.Rows < 0 || pos.Rows >= Rows ||  pos.Column < 0 ||  pos.Column >= Columns)
            {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
