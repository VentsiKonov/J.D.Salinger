using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class UprgradingItem : Item, IBuyable

    {
        public UprgradingItem(string name, int price)
            : base(name, price)
        {
        }
        public abstract IBuyable Buy(int bagalMoney);
        
    }
}
