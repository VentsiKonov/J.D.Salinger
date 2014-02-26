

namespace Waits
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Linq;

    static class GridDrawer
    {
        private const int SizeX = 15;
        private const int SizeY = 15;
        private const int MenuWidth = 50;

        public static int Rows { get; private set; }
        public static int Cols { get; private set; }

        private readonly static char[] specialCharsD = { '╔', '╦', '╗', '╠', '╬', '╣', '╚', '╩', '╝', '║', '═' };
        private readonly static char[] specialCharsS = { '┌', '┬', '┐', '├', '┼', '┤', '└', '┴', '┘', '│', '─', ' ' };

        public enum Menus
        {
            Sample,
            House,
            Pub,
            Granny,
            TownHall,
            MainCharacter
        };

        private readonly static char heroIcon = 'K';
        private readonly static char houseIcon = 'H';
        private readonly static char pubIcon = 'P';
        private readonly static char grannyIcon = 'G';
        private readonly static char townHallIcon = 'T';

        public static bool MenuVisible { get; private set; }

        private static char[,] theMatrix;

        public static MatrixCoords CurrentSelection
        {
            get;
            private set;
        }

        public static List<IRenderable> objectList = new List<IRenderable>();


        public static void Init()
        {
            // initialization

            Rows = SizeX;
            Cols = SizeY;

            Console.WindowHeight = Rows * 4 + 4;
            Console.WindowWidth = Cols * 6 + 2 + MenuWidth;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Console.CursorVisible = false;

            theMatrix = new char[Rows * 4 + 1, Cols * 6 + 1];

            Calc();

            DrawGridAndFrames();

            ReloadObjects();

            DrawObject(objectList.Where(o => (o is MainCharacter)).ElementAt(0)); // Draw Main Character

            Select(new MatrixCoords(0, 0)); // Initial selection coordinates

            DrawMenu(Menus.Sample);

        }

        public static void DrawGridAndFrames()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < theMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < theMatrix.GetLength(1); col++)
                {
                    result.Append(theMatrix[row, col]);
                }

                // Draw menu frame
                if (row == 0)
                {
                    result.Append(specialCharsD[0]);
                    result.Append(new string(specialCharsD[10], MenuWidth - 2));
                    result.Append(specialCharsD[2]);
                }
                else if (row == theMatrix.GetLength(0) - 1)
                {
                    result.Append(specialCharsD[6]);
                    result.Append(new string(specialCharsD[10], MenuWidth - 2));
                    result.Append(specialCharsD[8]);
                }
                else
                {
                    result.Append(specialCharsD[9] + new string(specialCharsS[11], MenuWidth - 2) + specialCharsD[9]);
                }
                // End of menu frame

                result.Append("\n");
            }

            Console.WriteLine(result.ToString());

        }

        private static void Calc()
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
            ClearMenu();

            Menus menuToLoad = Menus.Sample;
            foreach (IRenderable gameObject in objectList)
            {

                if (gameObject.Position == CurrentSelection)
                {
                    if (gameObject is MainCharacter)
                    {
                        menuToLoad = Menus.MainCharacter;
                    }
                    else if (gameObject is House)
                    {
                        menuToLoad = Menus.House;
                    }
                    else if (gameObject is Grandmother)
                    {
                        menuToLoad = Menus.Granny;
                    }
                    else if (gameObject is Pub)
                    {
                        menuToLoad = Menus.Pub;
                    }
                    else if (gameObject is TownHall)
                    {
                        menuToLoad = Menus.TownHall;
                    }
                    break;
                }
            }
            DrawMenu(menuToLoad);
        }

        private static void ClearCurrentSelection()
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

        public static void DrawObject(IRenderable objectToDraw)
        {
            // Calculations for the grid matrix coordinates
            Console.SetCursorPosition(objectToDraw.Position.Col * 6 + 3, objectToDraw.Position.Row * 4 + 2);
            char symbol = ' ';
            if (objectToDraw is MainCharacter)
            {
                symbol = heroIcon;
            }
            else if (objectToDraw is House)
            {
                symbol = houseIcon;
            }
            else if (objectToDraw is Grandmother)
            {
                symbol = grannyIcon;
            }
            else if (objectToDraw is Pub)
            {
                symbol = pubIcon;
            }
            else if (objectToDraw is TownHall)
            {
                symbol = townHallIcon;
            }
            Console.Write(symbol);

        }

        public static void DrawMenu(Menus choice)
        {
            // To be properly implemented
            int left = Console.BufferWidth - MenuWidth;
            int top = 2;

            string[] menu = LoadMenu(choice);

            string[] addition = {};
            switch(choice)
            {
                case Menus.MainCharacter:
                    addition = objectList.Where(o => (o is MainCharacter)).ElementAt(0).ToString().Split('\n');
                    break;
                case Menus.TownHall:
                    addition = objectList.Where(o => (o is TownHall)).ElementAt(0).ToString().Split('\n');
                    break;
                case Menus.Granny:
                    addition = objectList.Where(o => (o is Grandmother)).ElementAt(0).ToString().Split('\n');
                    break;
                case Menus.House:
                    addition = objectList.Where(o => (o is House)).ElementAt(0).ToString().Split('\n');
                    break;
                case Menus.Pub:
                    addition = objectList.Where(o => (o is Pub)).ElementAt(0).ToString().Split('\n');
                    break;
            }

            int i = 0;
            while (i < menu.Length)
            {
                Console.SetCursorPosition(left + 2, top + i);
                Console.Write(menu[i]);
                i++;
            }
            for (int j = 0; j < addition.Length-1; j++)
            {
                Console.SetCursorPosition(left + 2, top + i);
                Console.Write("\t" + addition[j]);
                i++;
            }
            
        }

        private static void ClearMenu()
        {
            int left = Console.BufferWidth - MenuWidth;
            int top = 2;

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(new string(specialCharsS[11], MenuWidth - 5));
            }
        }

        public static void ClearGridSymbol(MatrixCoords position)
        {
            Console.SetCursorPosition(position.Col * 6 + 3, position.Row * 4 + 2);
            Console.Write(specialCharsS[11]);
        }

        private static string[] LoadMenu(Menus choice)
        {
            StreamReader sr = new StreamReader("../../menus/" + choice.ToString() + ".txt");
            return sr.ReadToEnd().Split('\n');
        }

        public static void ReloadObjects()
        {
            foreach (IRenderable building in objectList)
            {
                if (!(building is MainCharacter))
                    DrawObject(building);
            }

        }
    }
}
