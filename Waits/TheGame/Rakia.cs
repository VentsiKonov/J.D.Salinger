using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class Rakia : Item
    {
        private const int GrozdovaPrice = 20;
        private const int SlivovaPrice = 40;
        private const int KaisievaPrice = 60;
        public Rakia(RakiaType rakiaType)
            : base(0)
        {
            this.Rakia = rakiaType;
            this.Price = GetRakiaPrice(rakiaType);
        }
        public RakiaType Rakia { get; set; }
        public int Price { get; set; }

       public int GetRakiaPrice(RakiaType rakia)
        {
            if (rakia.Equals(RakiaType.Grozdova))
            {
                return GrozdovaPrice;
            }
            else if (rakia.Equals(RakiaType.Slivova))
            {
                return SlivovaPrice;
            }
            else
            {
                return KaisievaPrice;
            }
        }
    }
}
