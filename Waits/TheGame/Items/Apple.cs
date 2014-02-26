using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Apple : SellableItem, ISellable
    {
        private const int ApplePriceInBagels = 5;
        public Apple()
            : base(ApplePriceInBagels)
        {
        }

        public override int Sell()
        {
            return ApplePriceInBagels;
        }
    }
}
