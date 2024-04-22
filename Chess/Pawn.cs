using board;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

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
            }

            else
            {
                pos.setValue(Position.Rows + 1, Position.Column);
                if (Board.ValidPosition(pos) && Available(pos))
                {
                    mat[pos.Rows, pos.Column] = true;
                }

                pos.setValue(Position.Rows + 2, Position.Column);
                if (Board.ValidPosition(pos) && Available(pos) && QteMovements == 0)
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
            }

            return mat;
        }
    }
}