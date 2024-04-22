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
                while (!match.Finished)
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Clear();
                        Screen.PrintMatch(match);


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origem = Screen.readPositionChess().toPosition();
                        match.ValidateOrigemPosition(origem);

                        bool[,] possiblePositions = match.Board.Piece(origem).PossibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readPositionChess().toPosition();
                        match.ValidateDestinyPosition(origem, destiny);

                        match.MakeAMove(origem, destiny);
                    }

                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}