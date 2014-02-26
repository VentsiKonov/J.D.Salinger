using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Rakia : Item, IBuyable
    {
        private const int GrozdovaPriceInBagels = 20;
        private const int SlivovaPriceInBagels = 40;
        private const int KaisievaPriceInBagels = 60;
        public Rakia(string name, RakiaType rakiaType)
            : base(name, 0)
        {
            this.KindOfRakia = rakiaType;
            this.Price = GetRakiaPrice(rakiaType);
        }
        public RakiaType KindOfRakia { get; set; }

        public int GetRakiaPrice(RakiaType rakia)
        {
            if (rakia.Equals(RakiaType.Grozdova))
            {
                return GrozdovaPriceInBagels;
            }
            else if (rakia.Equals(RakiaType.Slivova))
            {
                return SlivovaPriceInBagels;
            }
            else
            {
                return KaisievaPriceInBagels;
            }
        }
        public IBuyable Buy(int bagelMoney)
        {
            if (bagelMoney == GrozdovaPriceInBagels)
            {
                return new Rakia("Grozdova", RakiaType.Grozdova);
            }
            if (bagelMoney == SlivovaPriceInBagels)
            {
                return new Rakia("Slivova", RakiaType.Slivova);
            }
            if (bagelMoney == KaisievaPriceInBagels)
            {
                return new Rakia("Kaisieva", RakiaType.Kaisieva);
            }
            else
            {
                throw new InvalidMoneyAmountException(this.Price);
            }
        }
    }
}
