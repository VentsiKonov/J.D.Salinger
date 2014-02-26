using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public abstract class Item : GameObject
    {
        public Item(string name, int price)
            : base (name)
        {
            this.Price = price;
        }
        public int Price { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("Item: {0}\n", this.GetType().Name);
            var name = this as UprgradingItem;
            if (name != null)
            {
                output.AppendFormat("Name: {0}\n", this.Name);             
            }
            output.AppendFormat("Price in bagels: {0}\n", this.Price);

            return output.ToString();
        }
    }
}
