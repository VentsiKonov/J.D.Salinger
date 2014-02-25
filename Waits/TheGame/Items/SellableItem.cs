using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class SellableItem : Item, ISellable
    {
        public SellableItem(string name, int price)
            : base (name)
        {
            this.Price = price;
        }

        public int Price { get; set; }

        public int Sell()
        {
            throw new NotImplementedException();
        }
    }
}
