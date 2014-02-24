namespace Waits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class TheGame
    {
        static void Main()
        {
            Console.CursorVisible = false;

            //var renderer = new ConsoleRenderer(20, 40);

            //List<IRenderable> itemsToBeRendered = new List<IRenderable>()
            //{
            //    new House(new MatrixCoords(5, 10), 3, 4),
            //    new House(new MatrixCoords(12, 25), 5, 3),

            //    new TownHall(new MatrixCoords(3, 22), 3, 6),

            //    new Tree(new MatrixCoords(9, 9)),
            //    new Tree(new MatrixCoords(10, 11)),
            //    new Tree(new MatrixCoords(18, 22)),

            //    new MainCharacter("Vanio", Sex.Male, new MatrixCoords(15, 7)),
            //};

            //var engine = new GameEngine(renderer, itemsToBeRendered, 500);           

            //engine.Run();

            //PlayerMP3.Play(@"../../Songs/song04.mp3");

            //GridDrawer drawer = new GridDrawer();
            GridDrawer.Init();
            while (true)
            {
                InteractionManager.NewUserSelection();
            }

        }
    }
}
