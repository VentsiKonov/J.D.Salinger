using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class Inventory
    {
        private Dictionary<Item, int> items;
        private int money;

        public Inventory(int money, params Item[] items)
        {
            this.Money = money;
            foreach (Item item in items)
            {
                if (this.items.ContainsKey(item))
                {
                    this.items[item]++;
                }
                else
                {
                    this.items.Add(item, 1);
                }                
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

        public void Stash(Item item, int count)
        {
            if (this.items.ContainsKey(item))
            {
                this.items[item] += count;
            }
            else
            {
                this.items.Add(item, count);
            }      
        }

        public Item Take(Item item, int count)
        {
            if (this.items.ContainsKey(item))
            {
                if (this.items[item] < count)
	            {
		            //TODO some exception when you can't get that many items
	            }
                if (this.items[item] == count)
                {
                    this.items.Remove(item);
                }
                this.items[item] -= count;
            }
            else
            {
                //TODO some exception when you can't get that many items
            }                 
            return item;
            //TODO empty item?
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in this.items)
            {
                result.AppendFormat("{0} x {1}", item.Key, item.Value);
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
