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
        public bool Xeque { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Xeque = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            AddPieces();
        }

        public Piece ExecuteMovement(Position origem, Position destiny)
        {
            Piece p = Board.RemovePiece(origem);
            p.IncrementQteMovement();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.AddPiece(p, destiny);

            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origem, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destiny);
            p.DecrementQteMovement();
            if (capturedPiece != null)
            {
                Board.AddPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.AddPiece(p, origem);
        }

        public void MakeAMove(Position origem, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(origem, destiny);
            if (IsInCheck(ActualPlayer))
            {
                UndoMovement(origem, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in Xeque.");
            }
            if (IsInCheck(Enemy(ActualPlayer)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TestXequeMate(Enemy(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
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

        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        private Color Enemy(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }

        }

        public bool IsInCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException($"There's no king at the color {color} on the board.");
            }

            foreach (Piece x in PiecesInGame(Enemy(color)))
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[K.Position.Rows, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool TestXequeMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(x.Position, destiny);
                            bool testXeque = IsInCheck(color);
                            UndoMovement(x.Position, destiny, capturedPiece);
                            if (!testXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void AddNewPieces(char column, int row, Piece piece)
        {
            Board.AddPiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }
        private void AddPieces()
        {
            AddNewPieces('A', 1, new Tower(Board, Color.White));
            AddNewPieces('B', 1, new Horse(Board, Color.White));
            AddNewPieces('C', 1, new Bishop(Board, Color.White));
            AddNewPieces('D', 1, new Queen(Board, Color.White));
            AddNewPieces('E', 1, new King(Board, Color.White));
            AddNewPieces('F', 1, new Bishop(Board, Color.White));
            AddNewPieces('G', 1, new Horse(Board, Color.White));
            AddNewPieces('H', 1, new Tower(Board, Color.White));

            AddNewPieces('A', 2, new Pawn(Board, Color.White));
            AddNewPieces('B', 2, new Pawn(Board, Color.White));
            AddNewPieces('C', 2, new Pawn(Board, Color.White));
            AddNewPieces('D', 2, new Pawn(Board, Color.White));
            AddNewPieces('E', 2, new Pawn(Board, Color.White));
            AddNewPieces('F', 2, new Pawn(Board, Color.White));
            AddNewPieces('G', 2, new Pawn(Board, Color.White));
            AddNewPieces('H', 2, new Pawn(Board, Color.White));

            AddNewPieces('A', 8, new Tower(Board, Color.Black));
            AddNewPieces('B', 8, new Horse(Board, Color.Black));
            AddNewPieces('C', 8, new Bishop(Board, Color.Black));
            AddNewPieces('D', 8, new Queen(Board, Color.Black));
            AddNewPieces('E', 8, new King(Board, Color.Black));
            AddNewPieces('F', 8, new Bishop(Board, Color.Black));
            AddNewPieces('G', 8, new Horse(Board, Color.Black));
            AddNewPieces('H', 8, new Tower(Board, Color.Black));

            AddNewPieces('A', 7, new Pawn(Board, Color.Black));
            AddNewPieces('B', 7, new Pawn(Board, Color.Black));
            AddNewPieces('C', 7, new Pawn(Board, Color.Black));
            AddNewPieces('D', 7, new Pawn(Board, Color.Black));
            AddNewPieces('E', 7, new Pawn(Board, Color.Black));
            AddNewPieces('F', 7, new Pawn(Board, Color.Black));
            AddNewPieces('G', 7, new Pawn(Board, Color.Black));
            AddNewPieces('H', 7, new Pawn(Board, Color.Black));


        }
    }
}