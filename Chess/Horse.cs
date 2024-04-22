using board;

namespace Chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "H";
        }

        private bool canMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != this.Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            pos.setValue(Position.Rows - 1, Position.Column - 2);
            if(Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            pos.setValue(Position.Rows - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            pos.setValue(Position.Rows - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            pos.setValue(Position.Rows - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            pos.setValue(Position.Rows + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            pos.setValue(Position.Rows + 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            pos.setValue(Position.Rows + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            pos.setValue(Position.Rows + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            return mat;
        }
    }
}