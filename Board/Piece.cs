
namespace board
{
    abstract class Piece
    {
        public Position Position {  get; set; }
        public Color Color {  get; protected set; }
        public  int QteMovements { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.Position = null;
            this.Board = board;
            this.Color = color;
            this.QteMovements = 0;
        }

        public void IncrementQteMovement()
        {
            QteMovements++;
        }

        public bool ExistPossibleMovements()
        {
            bool[,] mat = PossibleMovement();
            {
                for (int i = 0; i < Board.Rows; i++)
                {
                    for(int j = 0; j < Board.Columns; j++)
                    {
                        if(mat[i, j])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool CanMoveToPosition(Position pos)
        {
            return PossibleMovement()[pos.Rows, pos.Column];
        }

        public abstract bool[,] PossibleMovement();
    }
}
