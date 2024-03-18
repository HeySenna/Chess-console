using board;

namespace Chess
{
    class ChessMatch
    {
        public Board board {  get; private set; }
        private int turn;
        private Color actualPlayer;
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board (8, 8);
            turn = 1;
            actualPlayer = Color.White;
            finished = false;
            addPieces();
        }

        public void executeMoviment(Position origem, Position destiny)
        {
            Piece p = board.removePiece(origem);
            p.incrementQteMoviment();
            Piece capturedPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
        }

        private void addPieces() 
        {
            board.addPiece(new Tower(board, Color.White), new ChessPosition('C', 1).toPosition());
            board.addPiece(new Tower(board, Color.White), new ChessPosition('C', 2).toPosition());
            board.addPiece(new Tower(board, Color.White), new ChessPosition('D', 2).toPosition());
            board.addPiece(new Tower(board, Color.White), new ChessPosition('E', 2).toPosition());
            board.addPiece(new Tower(board, Color.White), new ChessPosition('E', 1).toPosition());
            board.addPiece(new King(board, Color.White), new ChessPosition('D', 1).toPosition());

            board.addPiece(new Tower(board, Color.Black), new ChessPosition('C', 7).toPosition());
            board.addPiece(new Tower(board, Color.Black), new ChessPosition('C', 8).toPosition());
            board.addPiece(new Tower(board, Color.Black), new ChessPosition('D', 7).toPosition());
            board.addPiece(new Tower(board, Color.Black), new ChessPosition('E', 7).toPosition());
            board.addPiece(new Tower(board, Color.Black), new ChessPosition('E', 8).toPosition());
            board.addPiece(new King(board, Color.Black), new ChessPosition('D', 8).toPosition());
        }
    }
}
