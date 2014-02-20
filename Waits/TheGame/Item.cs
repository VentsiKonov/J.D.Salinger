using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    abstract class Item
    {
        private int price;

        public Item(int price)
        {
            this.Price = price;
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = price; }
        }
    }
}
