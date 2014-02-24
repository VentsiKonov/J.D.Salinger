using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{

    public static class InputEngine
    {
        private const ConsoleKey keyUp = ConsoleKey.UpArrow;
        private const ConsoleKey keyDown = ConsoleKey.DownArrow;
        private const ConsoleKey keyRight = ConsoleKey.RightArrow;
        private const ConsoleKey keyLeft = ConsoleKey.LeftArrow;

        public static void UserInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            MatrixCoords current = GridDrawer.CurrentSelection;
            switch (input.Key)
            {
                case keyUp:
                    if (current.Row >= 1)
                    {
                        GridDrawer.Select(new MatrixCoords(current.Row - 1, current.Col));
                    }
                    break;
                case keyDown:
                    if (current.Row < GridDrawer.Rows - 1)
                    {
                         GridDrawer.Select(new MatrixCoords(current.Row + 1, current.Col));
                         
                    }
                    break;
                case keyLeft:
                    if (current.Col >= 1)
                    {
                         GridDrawer.Select(new MatrixCoords(current.Row, current.Col - 1));
                    }
                    break;
                case keyRight:
                    if (current.Col < GridDrawer.Cols - 1)
                    {
                         GridDrawer.Select(new MatrixCoords(current.Row, current.Col + 1));
                    }
                    break;
                default:
                    break;
            }

        }

    }
}
