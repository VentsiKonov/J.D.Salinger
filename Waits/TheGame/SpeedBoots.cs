using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class SpeedBoots: Item, IUpgrader
    {
        public SpeedBoots(int price)
            : base(price)
        {
            this.IsUsed = false;
        }

        public bool IsUsed { get; set; }
    }
}
