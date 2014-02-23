using System;
using System.Text;

namespace Waits
{
    class GridDrawer
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        private char[] specialCharsD = { '╔', '╦', '╗', '╠', '╬', '╣', '╚', '╩', '╝', '║', '═' };
        private char[] specialCharsS = { '┌', '┬', '┐', '├', '┼', '┤', '└', '┴', '┘', '│', '─' };

        private char[,] theMatrix;

        public GridDrawer(int rows, int cols)
        {


            this.Rows = rows;
            this.Cols = cols;

            //Console.WindowHeight = this.Rows * 4 + 3;
            //Console.WindowWidth = this.Cols * 6 + 2;

            //Console.BufferHeight = Console.WindowHeight;
            //Console.BufferWidth = Console.WindowWidth;

            theMatrix = new char[this.Rows * 4 + 1, this.Cols * 6 + 1];
            this.Calc();
            this.Draw();
        }

        public void Draw()
        {
            Console.WriteLine(this);
        }

        public void Calc()
        {
            //char[,] theMatrix = new char[this.Rows * 4 + 1, this.Cols * 6 + 1];

            for (int row = 0; row < theMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < theMatrix.GetLength(1); col++)
                {
                    if (row == 0 && col == 0) theMatrix[row, col] = specialCharsD[0];
                    else if (row == 0 && col == theMatrix.GetLength(1) - 1) theMatrix[row, col] = specialCharsD[2];
                    else if (row == theMatrix.GetLength(0) - 1 && col == 0) theMatrix[row, col] = specialCharsD[6];
                    else if (row == theMatrix.GetLength(0) - 1 && col == theMatrix.GetLength(1) - 1) theMatrix[row, col] = specialCharsD[8];
                    else if (row == 0 && col % 6 == 0) theMatrix[row, col] = specialCharsD[1];
                    else if (row == theMatrix.GetLength(0) - 1 && col % 6 == 0) theMatrix[row, col] = specialCharsD[7];
                    else if (row % 4 == 0 && col == 0) theMatrix[row, col] = specialCharsD[3];
                    else if (row % 4 == 0 && col == theMatrix.GetLength(1) - 1) theMatrix[row, col] = specialCharsD[5];
                    else if (row % 4 == 0 && col % 6 == 0) theMatrix[row, col] = specialCharsD[4];
                    else if (row % 4 == 0) theMatrix[row, col] = specialCharsD[10];
                    else if (row % 4 != 0 && col % 6 == 0) theMatrix[row, col] = specialCharsD[9];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < theMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < theMatrix.GetLength(1); col++)
                {
                    result.Append(theMatrix[row, col]);
                }
                result.Append("\n");
            }
            return result.ToString();
        }

    }
}
