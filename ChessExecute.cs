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
                        Screen.printBoard(match.GetBoard());
                        Console.WriteLine();
                        Console.WriteLine($"Turn: {match.Turn}");
                        Console.WriteLine($"Waiting move: {match.ActualPlayer}");


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origem = Screen.readPositionChess().toPosition();
                        match.ValidateOrigemPosition(origem);

                        bool[,] possiblePositions = match.GetBoard().Piece(origem).PossibleMovement();

                        Console.Clear();
                        Screen.printBoard(match.GetBoard(), possiblePositions);

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
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}