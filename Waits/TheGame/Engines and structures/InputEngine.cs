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
        private const ConsoleKey keyEnter = ConsoleKey.Enter;
        private const ConsoleKey keyM = ConsoleKey.M;

        public static void UserInput(MainCharacter hero)
        {
            ConsoleKey inputKey = Console.ReadKey(true).Key;

            MatrixCoords current = GridDrawer.CurrentSelection;
            switch (inputKey)
            {
                case keyUp:
                    if (current.Row >= 1)
                    {
                        GridDrawer.Select(new MatrixCoords(current.Row - 1, current.Col));
                        GridDrawer.DrawMenu(GridDrawer.Menus.Sample);
                    }
                    break;
                case keyDown:
                    if (current.Row < GridDrawer.Rows - 1)
                    {
                        GridDrawer.Select(new MatrixCoords(current.Row + 1, current.Col));
                        GridDrawer.DrawMenu(GridDrawer.Menus.Sample);

                    }
                    break;
                case keyLeft:
                    if (current.Col >= 1)
                    {
                        GridDrawer.Select(new MatrixCoords(current.Row, current.Col - 1));
                        GridDrawer.DrawMenu(GridDrawer.Menus.Sample);

                    }
                    break;
                case keyRight:
                    if (current.Col < GridDrawer.Cols - 1)
                    {
                        GridDrawer.Select(new MatrixCoords(current.Row, current.Col + 1));
                        GridDrawer.DrawMenu(GridDrawer.Menus.Sample);

                    }
                    break;
                case keyEnter:
                    //GridDrawer.ToggleMenu();
                    break;
                case keyM:
                        GridDrawer.ClearGridSymbol(hero.Position);
                        hero.Move(GridDrawer.CurrentSelection);
                    break;
                default:
                    // Empty
                    break;
            }

        }


    }
}
