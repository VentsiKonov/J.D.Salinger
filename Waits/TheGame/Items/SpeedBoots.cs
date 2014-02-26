using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class SpeedBoots: UprgradingItem, IBuyable
    {
        //Using singleton design pattern.
        private static readonly SpeedBoots SingleBoots;
        private const string BootsName = "Carvuli";
        private const int BootsPriceInBagels = 8;

        private SpeedBoots()
            : base(BootsName, BootsPriceInBagels)
        {
        }

        public static SpeedBoots BootsInstance
        {
            get
            {
                return SingleBoots;
            }
        }

        public override IBuyable Buy(int bagelMoney)
        {
            if (bagelMoney != BootsInstance.Price)
            {
                throw new InvalidMoneyAmountException(this.Price);
            }
            return BootsInstance;
        }
    }
}
