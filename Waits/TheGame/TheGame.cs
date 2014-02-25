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
            MainCharacter hero = new MainCharacter("User", Sex.Male, new MatrixCoords(0, 3), new List<ISellable>());
            
            GridDrawer.Init(new IRenderable[] { hero});
            while (true)
            {
                InputEngine.UserInput(hero);

            }

        }
    }
}
