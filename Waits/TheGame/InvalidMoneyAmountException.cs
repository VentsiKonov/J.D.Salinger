using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class InvalidMoneyAmountException : ApplicationException
    {
        public int PriceInBagels { get; private set; }
        public InvalidMoneyAmountException(int requiredBagels)
        {
            this.PriceInBagels = requiredBagels;
        }

        public override string Message
        {
            get
            {
                string msg = String.Format("Unadequate pay amount. The price in bagels is {0}.", this.PriceInBagels);
                return msg;
            }
        }
    }
}
