using System;
using System.Text;

namespace Waits
{
    static class GridDrawer
    {
        private const int SizeX = 15;
        private const int SizeY = 15;
        private const int menuWidth = 50;

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

            Console.WindowHeight = Rows * 4 + 4;
            Console.WindowWidth = Cols * 6 + 2 + menuWidth;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            theMatrix = new char[Rows * 4 + 1, Cols * 6 + 1];
            Calc();

            Draw();

            Select(new MatrixCoords(0, 0));

        }

        public static void Draw()
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

            Console.WriteLine(result.ToString());
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
            int y = CurrentSelection.Row * 4 + 1;
            int x = CurrentSelection.Col * 6 + 1;

            Console.SetCursorPosition(x, y);
            Console.Write(specialCharsS[0]);

            Console.SetCursorPosition(x + 1, y);
            Console.Write(specialCharsS[10]);

            Console.SetCursorPosition(x + 2, y);
            Console.Write(specialCharsS[10]);

            Console.SetCursorPosition(x + 3, y);
            Console.Write(specialCharsS[10]);

            Console.SetCursorPosition(x + 4, y);
            Console.Write(specialCharsS[2]);

            Console.SetCursorPosition(x, y + 1);
            Console.Write(specialCharsS[9]);

            Console.SetCursorPosition(x + 4, y + 1);
            Console.Write(specialCharsS[9]);

            Console.SetCursorPosition(x, y + 2);
            Console.Write(specialCharsS[6]);

            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write(specialCharsS[10]);

            Console.SetCursorPosition(x + 2, y + 2);
            Console.Write(specialCharsS[10]);

            Console.SetCursorPosition(x + 3, y + 2);
            Console.Write(specialCharsS[10]);

            Console.SetCursorPosition(x + 4, y + 2);
            Console.Write(specialCharsS[8]);

            Console.SetCursorPosition(0, Console.WindowHeight - 1); // Don't missdraw

        }

        public static void Select(MatrixCoords coordinates)
        {
            ClearCurrentSelection();
            CurrentSelection = coordinates;
            DrawCurrentSelection();
        }

        public static void ClearCurrentSelection()
        {
            int y = CurrentSelection.Row * 4 + 1;
            int x = CurrentSelection.Col * 6 + 1;

            Console.SetCursorPosition(x, y);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 1, y);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 2, y);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 3, y);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 4, y);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x, y + 1);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 4, y + 1);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x, y + 2);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 1, y + 2);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 2, y + 2);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 3, y + 2);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(x + 4, y + 2);
            Console.Write(specialCharsS[11]);

            Console.SetCursorPosition(0, Console.WindowHeight - 1); // Don't missdraw

        }


    }
}
