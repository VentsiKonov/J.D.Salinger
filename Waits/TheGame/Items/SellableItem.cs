using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class SellableItem : Item, ISellable
    {
        public SellableItem(int price)
            : base ("sellable", price)
            //Sellable items dont neeed an explicit name.
        {
        }
        public abstract int Sell();
        public override string ToString()
        {
            var output = base.ToString();
            output += "Use: Can be sold for other items in the shop.";

            return output;
        }
    }
}
