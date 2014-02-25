using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class Item : GameObject
    {
        private int price;

        public Item(string name)
            : base (name)
        {
        }        
    }
}
