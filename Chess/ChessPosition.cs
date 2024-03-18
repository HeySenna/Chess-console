using board;

namespace Chess
{
    class ChessPosition
    {
        public char column { get; set; }
        public int row { get; set; }

        public ChessPosition(char column, int row)
        {
            this.column = column;
            this.row = row;
        }

        public Position toPosition()
        {
            int columnNumericValue = column - 'A';
            return new Position(8 - row, columnNumericValue);       
        }

        public override string ToString()
        {
            return "" + column + row;
        }
    }
}