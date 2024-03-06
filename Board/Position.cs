
namespace board
{
    class Position
    {
        public int rows { get; set; }
        public int column { get; set; }

        public Position(int rows, int column)
        {
            this.rows = rows;
            this.column = column;
        }

        public override string ToString()
        {
            return rows
                + ","
                + column;
        }

    }
}
