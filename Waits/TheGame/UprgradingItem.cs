using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class UprgradingItem : Item, IUpgrader
    {
        public UprgradingItem(string name)
            : base(name)
        {
            this.IsUsed = false;
        }
        public bool IsUsed { get; set; }
    }
}
