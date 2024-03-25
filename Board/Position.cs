
namespace board
{
    class Position
    {
        public int Rows { get; set; }
        public int Column { get; set; }

        public Position(int rows, int column)
        {
            this.Rows = rows;
            this.Column = column;
        }

        public void setValue(int rows, int column)
        {
            this.Rows = rows;
            this.Column = column;
        }

        public override string ToString()
        {
            return Rows
                + ", "
                + Column;
        }

    }
}
