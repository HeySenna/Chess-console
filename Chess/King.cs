using board;

namespace Chess
{
    class King : Piece
    {
        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != this.Color;
        }

        private bool TestTowerCastling(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Tower && p.Color == Color && p.QteMovements == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // North
            pos.setValue(Position.Rows - 1, Position.Column);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            // North east
            pos.setValue(Position.Rows - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            // East
            pos.setValue(Position.Rows, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //South east
            pos.setValue(Position.Rows + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //South
            pos.setValue(Position.Rows + 1, Position.Column);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //South west
            pos.setValue(Position.Rows + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //West
            pos.setValue(Position.Rows, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //North west
            pos.setValue(Position.Rows -1 , Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            // # Special move:  Castling
            if(QteMovements == 0 && !match.Xeque)
            {
                // Short castling
                Position posT1 = new Position(pos.Rows, pos.Column + 3);
                if(TestTowerCastling(posT1))
                {
                    Position p1 = new Position(Position.Rows, pos.Column + 1);
                    Position p2 = new Position(Position.Rows, pos.Column + 2);
                    if(Board.Piece(p1) == null &&  Board.Piece(p2) == null)
                    {
                        mat[Position.Rows, Position.Column + 2] = true;
                    }
                }

                // Long castling
                Position posT2 = new Position(pos.Rows, pos.Column - 4);
                if (TestTowerCastling(posT2))
                {
                    Position p1 = new Position(Position.Rows, pos.Column - 1);
                    Position p2 = new Position(Position.Rows, pos.Column - 2);
                    Position p3 = new Position(Position.Rows, pos.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        mat[Position.Rows, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
