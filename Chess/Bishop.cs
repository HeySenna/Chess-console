using board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
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

            // North West
            pos.setValue(Position.Rows - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[Board.Rows, Board.Columns] = true;
                if(Board.Piece(pos).Color != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValue(pos.Rows -1, pos.Column - 1);
            }

            // North east
            pos.setValue(Position.Rows - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[Board.Rows, Board.Columns] = true;
                if (Board.Piece(pos).Color != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValue(pos.Rows - 1, pos.Column + 1);
            }

            //South east
            pos.setValue(Position.Rows + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[Board.Rows, Board.Columns] = true;
                if (Board.Piece(pos).Color != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValue(pos.Rows + 1, pos.Column + 1);
            }

            //South west
            pos.setValue(Position.Rows + 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[Board.Rows, Board.Columns] = true;
                if (Board.Piece(pos).Color != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValue(pos.Rows + 1, pos.Column - 1);
            }
            return mat;
        }
    }
}