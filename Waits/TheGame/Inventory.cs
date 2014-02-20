using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class Inventory
    {
        private List<Item> items;
        private int money;

        public Inventory(int money, params Item[] items)
        {
            this.Money = money;
            foreach (Item item in items)
            {
                this.items.Add(item);
            }
        }

        public int Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money can't be less than 0.");
                }
                this.money = value;
            }
        }

        public void Stash(Item item)
        {
            items.Add(item);
        }

        public Item Take(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                return item;
            }
            return item;//TODO empty item?
        }
    }
}
