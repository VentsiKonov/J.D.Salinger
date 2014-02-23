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

            var field = new ConsoleRenderer(20, 40);

            var house1 = new House(new MatrixCoords(5, 10), 3, 4);
            var house2 = new House(new MatrixCoords(12, 25), 5, 3);

            var townHall = new TownHall(new MatrixCoords(3, 22), 3, 6);

            var tree1 = new Tree(new MatrixCoords(9, 9));
            var tree2 = new Tree(new MatrixCoords(10, 11));
            var tree3 = new Tree(new MatrixCoords(18, 22));

            field.EnqueueForRendering(house1);
            field.EnqueueForRendering(house2);
            field.EnqueueForRendering(tree1);
            field.EnqueueForRendering(tree2);
            field.EnqueueForRendering(tree3);
            field.EnqueueForRendering(townHall);


            field.RenderAll();
            PlayerMP3.Play(@"../../Songs/song04.mp3");
        }
    }
}
