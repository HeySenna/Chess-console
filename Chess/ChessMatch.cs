using board;

namespace Chess
{
    class ChessMatch
    {
        private Board board;

        public Board GetBoard()
        {
            return board;
        }

        public void SetBoard(Board value)
        {
            board = value;
        }

        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            board = new Board (8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            addPieces();
        }

        public void ExecuteMovement(Position origem, Position destiny)
        {
            Piece p = board.RemovePiece(origem);
            p.IncrementQteMovement();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(p, destiny);
        }

        public void MakeAMove(Position origem, Position destiny)
        {
            ExecuteMovement(origem, destiny);
            Turn ++;
            ChangePlayer();
        }
        public void ValidateOrigemPosition(Position pos)
        {
            if (board.Piece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen position!");
            }

            if(ActualPlayer != board.Piece(pos).Color) 
            {
                throw new BoardException("The chosen piece isn't yours!");
            }

            if (!board.Piece(pos).ExistPossibleMovements())
            {
                throw new BoardException("There is no possible movements for the chosen piece!");
            }
        }

        public void ValidateDestinyPosition(Position origem, Position destiny)
        {
            if (!board.Piece(origem).CanMoveToPosition(destiny))
            {
                throw new BoardException("Invalid destiny position.");
            }
        }
        private void ChangePlayer()
        {
            if(ActualPlayer == Color.White)
            {
               ActualPlayer = Color.Black;
            }

            else
            {
                ActualPlayer = Color.White;
            }
        }

        private void addPieces() 
        {
            board.AddPiece(new Tower(board, Color.White), new ChessPosition('C', 1).toPosition());
            board.AddPiece(new Tower(board, Color.White), new ChessPosition('C', 2).toPosition());
            board.AddPiece(new Tower(board, Color.White), new ChessPosition('D', 2).toPosition());
            board.AddPiece(new Tower(board, Color.White), new ChessPosition('E', 2).toPosition());
            board.AddPiece(new Tower(board, Color.White), new ChessPosition('E', 1).toPosition());
            board.AddPiece(new King(board, Color.White), new ChessPosition('D', 1).toPosition());

            board.AddPiece(new Tower(board, Color.Black), new ChessPosition('C', 7).toPosition());
            board.AddPiece(new Tower(board, Color.Black), new ChessPosition('C', 8).toPosition());
            board.AddPiece(new Tower(board, Color.Black), new ChessPosition('D', 7).toPosition());
            board.AddPiece(new Tower(board, Color.Black), new ChessPosition('E', 7).toPosition());
            board.AddPiece(new Tower(board, Color.Black), new ChessPosition('E', 8).toPosition());
            board.AddPiece(new King(board, Color.Black), new ChessPosition('D', 8).toPosition());
        }
    }
}
