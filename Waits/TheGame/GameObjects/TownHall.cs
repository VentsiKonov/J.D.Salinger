using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class TownHall : Building, IRenderable
    {
        private const string TownHallName = "Town Hall";
        public TownHall(MatrixCoords position)
            : base (TownHallName, position)
        { 
            // empty
        }

        public bool DoYouWin(MainCharacter hero)
        {
            if (CalculateRakiaCost(hero) < 100)
            {
                return false;
            }
            return true;
        }

        private static int CalculateRakiaCost(MainCharacter hero)
        {
            int allRakiaPrice = 0;
            foreach (var item in hero.Bag)
            {
                var isRakia = item as Rakia;
                if (isRakia != null)
                {
                    allRakiaPrice += isRakia.Price;
                }
            }
            return allRakiaPrice;
        }

    }
}
