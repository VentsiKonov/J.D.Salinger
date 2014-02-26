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


            MainCharacter hero = new MainCharacter("User", Sex.Male, new MatrixCoords(0, 3), new List<ISellable>(),
                new List<Song>());

            //Grandmother hall = new Grandmother("baba", Sex.Female, new MatrixCoords(4, 4));

            //MarketPlace market = new MarketPlace("market", new MatrixCoords(7, 7));

            //House house = new House("nane", new MatrixCoords(3,7), 2);



            GridDrawer.Init();
            GameObjectCreator listOfObjects = new GameObjectCreator(8);
            GridDrawer.StartScreen();

            GridDrawer.Init();
            

            while (true)
            {
                InputEngine.UserInput(hero);

            }

        }
    }
}
