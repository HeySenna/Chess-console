using board;
using Chess;

namespace Chess_console
{
    class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            printBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Turn: {match.Turn}");
            Console.WriteLine($"Waiting move: {match.ActualPlayer}");
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Color.White));
            Console.WriteLine();

            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write($"{x} ");
            }
            Console.Write("]");
        }
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    printPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void printBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor patternBackgroud = ConsoleColor.Black;
            ConsoleColor alternedBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alternedBackground;
                    }

                    else
                    {
                        Console.BackgroundColor = patternBackgroud;
                    }
                    printPiece(board.Piece(i, j));
                    Console.BackgroundColor = patternBackgroud;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = patternBackgroud;
        }

        public static ChessPosition readPositionChess()
        {
            string s = Console.ReadLine().ToUpper();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);

        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }

            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }

                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}