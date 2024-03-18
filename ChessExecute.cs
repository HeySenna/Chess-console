using board;
using Chess;

namespace Chess_console
{
    public class ChessExecute
    {
        public static void Execute()
        {
            try
            {
                ChessMatch match = new ChessMatch();
                while(!match.finished)
                {
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origem = Screen.readPositionChess().toPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readPositionChess().toPosition();

                    match.executeMoviment(origem, destiny);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}