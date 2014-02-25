using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class SpeedBoots: UprgradingItem, IUpgrader
    {
        public SpeedBoots(string name, int price)
            : base(name)
        {
        }
    }
}
