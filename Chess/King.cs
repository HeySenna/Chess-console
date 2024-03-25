using board;

namespace Chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

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

        public override bool[,] PossibleMovement()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // North
            pos.setValue(Position.Rows - 1, Position.Column);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            // North east
            pos.setValue(Position.Rows - 1, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            // East
            pos.setValue(Position.Rows, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //South east
            pos.setValue(Position.Rows + 1, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //South
            pos.setValue(Position.Rows + 1, Position.Column);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //South west
            pos.setValue(Position.Rows + 1, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //West
            pos.setValue(Position.Rows, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            //North west
            pos.setValue(Position.Rows -1 , Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Rows, pos.Column] = true;
            }

            return mat;
        }
    }
}
