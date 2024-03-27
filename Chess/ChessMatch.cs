using board;

namespace Chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }
        public HashSet<Piece> Pieces;
        public HashSet<Piece> Captured;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            AddPieces();
        }

        public void ExecuteMovement(Position origem, Position destiny)
        {
            Piece p = Board.RemovePiece(origem);
            p.IncrementQteMovement();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);

            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }

        }

        public void MakeAMove(Position origem, Position destiny)
        {
            ExecuteMovement(origem, destiny);
            Turn++;
            ChangePlayer();
        }
        public void ValidateOrigemPosition(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen position!");
            }

            if (ActualPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The chosen piece isn't yours!");
            }

            if (!Board.Piece(pos).ExistPossibleMovements())
            {
                throw new BoardException("There is no possible movements for the chosen piece!");
            }
        }

        public void ValidateDestinyPosition(Position origem, Position destiny)
        {
            if (!Board.Piece(origem).CanMoveToPosition(destiny))
            {
                throw new BoardException("Invalid destiny position.");
            }
        }
        private void ChangePlayer()
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }

            else
            {
                ActualPlayer = Color.White;
            }
        }
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }
        public void AddNewPieces (char column, int row, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }
        private void AddPieces()
        {
            AddNewPieces('C', 1, new Tower(Board, Color.White));
            AddNewPieces('C', 2, new Tower(Board, Color.White));
            AddNewPieces('D', 2, new Tower(Board, Color.White));
            AddNewPieces('E', 2, new Tower(Board, Color.White));
            AddNewPieces('E', 1, new Tower(Board, Color.White));
            AddNewPieces('D', 1, new King(Board, Color.White));

            AddNewPieces('C', 7, new Tower(Board, Color.Black));
            AddNewPieces('C', 8, new Tower(Board, Color.Black));
            AddNewPieces('D', 7, new Tower(Board, Color.Black));
            AddNewPieces('E', 7, new Tower(Board, Color.Black));
            AddNewPieces('E', 8, new Tower(Board, Color.Black));
            AddNewPieces('D', 8, new King(Board, Color.Black));

        }
    }
}