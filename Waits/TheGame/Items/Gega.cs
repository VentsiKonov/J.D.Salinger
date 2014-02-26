using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Gega: UprgradingItem, IBuyable
    {
        //Using singleton design pattern.
        private static readonly Gega SingleGega;
        private const string GegaName = "Gega of Awesomeness";
        private const int GegaPriceInBagels = 10;

        private Gega()
            : base(GegaName, GegaPriceInBagels)
        {
        }

        public static Gega GegaInstance
        {
            get
            {
                return SingleGega;
            }
        }

        public override IBuyable Buy(int bagelMoney)
        {
            if (bagelMoney != GegaInstance.Price)
            {
                throw new InvalidMoneyAmountException(this.Price);
            }
            return GegaInstance;
        }
    }
}
