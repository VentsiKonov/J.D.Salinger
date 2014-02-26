using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class MarketPlace : Building, IRenderable
    {
        public MarketPlace(string name, MatrixCoords position)
            : base(name, position)
        {
            // empty
        }
    }
}
