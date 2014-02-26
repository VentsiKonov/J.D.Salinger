using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class Item : GameObject
    {
        public Item(string name, int price)
            : base (name)
        {
            this.Price = price;
        }
        public int Price { get; set; }

    }
}
