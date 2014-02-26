using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class MarketPlace : Building, IRenderable
    {
        private const string GegaRequest = "gega";
        private const string BootsRequest = "boots";
        public MarketPlace(string name, MatrixCoords position)
            : base(name, position)
        {
            // empty
        }

        public IBuyable SellItem(string requested, MainCharacter hero)
        {
            CheckPayAmount(hero);
            if (requested == GegaRequest)
            {
                return Gega.GegaInstance;
            }
            else if (requested == BootsRequest)
            {
                return SpeedBoots.BootsInstance;
            }
            return null;
        }

        private bool CheckPayAmount(MainCharacter hero)
        {
            throw new NotImplementedException();
        }


    }
}
