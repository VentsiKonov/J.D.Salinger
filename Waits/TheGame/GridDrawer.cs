using System;
using System.Text;

namespace Waits
{
    static class GridDrawer
    {
        private const int SizeX = 15;
        private const int SizeY = 15;

        public static int Rows { get; private set; }
        public static int Cols { get; private set; }

        private static char[] specialCharsD = { '╔', '╦', '╗', '╠', '╬', '╣', '╚', '╩', '╝', '║', '═' };
        private static char[] specialCharsS = { '┌', '┬', '┐', '├', '┼', '┤', '└', '┴', '┘', '│', '─', ' ' };

        private static char[,] theMatrix;

        public static MatrixCoords CurrentSelection
        {
            get;
            private set;
        }

        public static void Init()
        {
            // initialization
            

            Rows = SizeX;
            Cols = SizeY;

            Console.WindowHeight = Rows * 4 + 3;
            Console.WindowWidth = Cols * 6 + 2;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            theMatrix = new char[Rows * 4 + 1, Cols * 6 + 1];
            Calc();

            Select(new MatrixCoords(0,0));
            
            //this.Draw();
        }

        public static void Draw()
        {
            Console.WriteLine(ToString());
        }

        public static void Calc()
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

        private static void DrawCurrentSelection()
        {
            int x = CurrentSelection.Row * 4 + 1;
            int y = CurrentSelection.Col * 6 + 1;

            theMatrix[x, y] = specialCharsS[0];
            theMatrix[x, y + 1] = specialCharsS[10];
            theMatrix[x, y + 2] = specialCharsS[10];
            theMatrix[x, y + 3] = specialCharsS[10];
            theMatrix[x, y + 4] = specialCharsS[2];
            theMatrix[x + 1, y] = specialCharsS[9];
            theMatrix[x + 1, y + 4] = specialCharsS[9];
            theMatrix[x + 2, y] = specialCharsS[6];
            theMatrix[x + 2, y + 1] = specialCharsS[10];
            theMatrix[x + 2, y + 2] = specialCharsS[10];
            theMatrix[x + 2, y + 3] = specialCharsS[10];
            theMatrix[x + 2, y + 4] = specialCharsS[8];

            Draw();
        }

        public static void Select(MatrixCoords coordinates)
        {
            ClearCurrentSelection();
            CurrentSelection = coordinates;
            DrawCurrentSelection();
        }

        public static void ClearCurrentSelection()
        {
            int x = CurrentSelection.Row * 4 + 1;
            int y = CurrentSelection.Col * 6 + 1;

            theMatrix[x, y] = specialCharsS[11];
            theMatrix[x, y + 1] = specialCharsS[11];
            theMatrix[x, y + 2] = specialCharsS[11];
            theMatrix[x, y + 3] = specialCharsS[11];
            theMatrix[x, y + 4] = specialCharsS[11];
            theMatrix[x + 1, y] = specialCharsS[11];
            theMatrix[x + 1, y + 4] = specialCharsS[11];
            theMatrix[x + 2, y] = specialCharsS[11];
            theMatrix[x + 2, y + 1] = specialCharsS[11];
            theMatrix[x + 2, y + 2] = specialCharsS[11];
            theMatrix[x + 2, y + 3] = specialCharsS[11];
            theMatrix[x + 2, y + 4] = specialCharsS[11];

            Draw();
        }

        public static string ToString()
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
