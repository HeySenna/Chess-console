using board;

namespace Chess
{
    class Pawn : Piece
    {

        private ChessMatch Match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.Match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        public bool ExistEnemy(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Available(Position pos)
        {
            return Board.Piece(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if(Color == Color.White)
            { 
                pos.setValue(Position.Rows - 1, Position.Column);
                if(Board.ValidPosition(pos) && Available(pos))
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                pos.setValue(Position.Rows - 2, Position.Column);
                if (Board.ValidPosition(pos) && Available(pos) && QteMovements == 0)
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                pos.setValue(Position.Rows - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                pos.setValue(Position.Rows - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                // Special Move: En passant
                if(Position.Rows == 3)
                {
                    Position right = new Position(Position.Rows, Position.Column - 1);
                    if(Board.ValidPosition(right) && ExistEnemy(right) && Board.Piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Rows -1, right.Column] = true;
                    }

                    Position left = new Position(Position.Rows, Position.Column + 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.Piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Rows -1, left.Column] = true;
                    }
                }
            }

            else
            {
                pos.setValue(Position.Rows + 1, Position.Column);
                if (Board.ValidPosition(pos) && Available(pos))
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                pos.setValue(Position.Rows + 2, Position.Column);
                Position p2 = new Position(Position.Rows + 1, Position.Column);
                if (Board.ValidPosition(p2) && Available(p2)
                    && Board.ValidPosition(pos) && Available(pos) && QteMovements == 0)
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                pos.setValue(Position.Rows + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                pos.setValue(Position.Rows + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                // Special Move: En passant
                if (Position.Rows == 4)
                {
                    Position right = new Position(Position.Rows, Position.Column - 1);
                    if (Board.ValidPosition(right) && ExistEnemy(right) && Board.Piece(right) == Match.VulnerableEnPassant)
                    {
                        mat[right.Rows + 1, right.Column] = true;
                    }

                    Position left = new Position(Position.Rows, Position.Column + 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.Piece(left) == Match.VulnerableEnPassant)
                    {
                        mat[left.Rows + 1, left.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}