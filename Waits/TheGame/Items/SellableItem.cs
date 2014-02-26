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
    }
}
