using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Oshav : SellableItem, ISellable
    {
        private const int OshavPriceInBagels = 5;
        public Oshav()
            : base(OshavPriceInBagels)
        {
        }
        public override int Sell()
        {
            return OshavPriceInBagels;
        }
    }
}
