using board;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "Q";
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

            //North
            pos.setValue(Position.Rows - 1, Position.Column);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Rows = pos.Rows - 1;
            }

            //South
            pos.setValue(Position.Rows + 1, Position.Column);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Rows = pos.Rows + 1;
            }

            //East
            pos.setValue(Position.Rows, Position.Column + 1);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //West
            pos.setValue(Position.Rows, Position.Column - 1);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;

                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            // North West
            pos.setValue(Position.Rows - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[Board.Rows, Board.Columns] = true;
                if (Board.Piece(pos).Color != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValue(pos.Rows - 1, pos.Column - 1);
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