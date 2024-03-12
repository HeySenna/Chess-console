using board;
using chess;

namespace Chess_console
{
    public class ChessExecute
    {
        public static void Execute()
        {
            try
            {
                Board board = new Board(8, 8);

                board.addPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.addPiece(new Tower(board, Color.Black), new Position(1, 9));
                board.addPiece(new King(board, Color.Black), new Position(0, 2));

                Screen.printBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
