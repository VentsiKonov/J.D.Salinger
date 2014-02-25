using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class MainCharacter : Character, IRenderable
    {
        private const char MainChar = (char)38;
        private const int InitialCapacity = 25;
        private const int InitialBagelCount = 25;
        public MainCharacter(string name, Sex sex, MatrixCoords position, List<Item> itemList)
            : base(name, sex, position)
        {
            this.PlayerChar = MainChar;
            this.BagelCount = InitialBagelCount;
            this.Upgrades = new List<IUpgrader>();
            this.BagelsCaringCapacity = InitialBagelCount;

            if (itemList == null)
            {
                this.Bag = new List<Item>();
            }
            else
            {
                this.Bag = itemList;
            }
        }

        public int BagelCount { get; set; }
        public  List<IUpgrader> Upgrades { get; set; }
        public List<Item> Bag { get; set; }
        public int BagelsCaringCapacity { get; set; }

        public bool BagIsFull()
        {
            if (this.Bag.Count == 5)
            {
                return true;
            }
            return false;
        }

        public void UpgradingCharacter(IUpgrader item)
        {
            this.Upgrades.Add(item);
        }


    }
}
