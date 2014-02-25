using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Gega: Item, IUpgrader
    {
        public Gega(int price)
            : base(price)
        {
            this.IsUsed = false;
        }

        public bool IsUsed { get; set; }
    }
}
