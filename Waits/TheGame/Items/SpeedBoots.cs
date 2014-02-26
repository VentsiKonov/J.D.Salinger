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
        private static SpeedBoots SingleBoots;
        private const string BootsName = "Carvuli";
        private const int BootsPriceInBagels = 8;

        private SpeedBoots()
            : base(BootsName, BootsPriceInBagels)
        { }

        public static SpeedBoots BootsInstance
        {
            get
            {
                if (SingleBoots == null)
                {
                    SingleBoots = new SpeedBoots();
                }
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
        public override string ToString()
        {
            var output = new StringBuilder();
            var baseString = base.ToString();

            output.Append(baseString);
            output.AppendLine("Use: The speed boots are used to allow");
            output.AppendLine("the wait to make more moves on the board");
            output.AppendLine("without having to eat bagels.");

            return output.ToString();
        }
    }
}
