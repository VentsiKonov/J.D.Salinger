using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class MainCharacter : Character, IRenderable, IMovable, IUpgradable
    {
        private const char MainChar = (char)38;
        private const int InitialCapacity = 25;
        private const int InitialBagelCount = 15;
        public MainCharacter(string name, Sex sex, MatrixCoords position, List<ISellable> itemList, List<Song> initialSongList)
            : base(name, sex, position)
        {
            this.PlayerChar = MainChar;
            this.BagelCount = InitialBagelCount;
            this.Upgrades = new List<IBuyable>();
            this.WaitSongs = initialSongList;
            this.BagelsCaringCapacity = InitialBagelCount;

            if (itemList == null)
            {
                this.Bag = new List<ISellable>();
            }
            else
            {
                this.Bag = itemList;
            }
        }

        public int BagelCount { get; set; }
        public List<IBuyable> Upgrades { get; set; }
        public List<ISellable> Bag { get; set; }
        public List<Song> WaitSongs { get; set; }
        public int BagelsCaringCapacity { get; set; }

        public bool BagIsFull()
        {
            if (this.Bag.Count == 5)
            {
                return true;
            }
            return false;
        }

        public void Upgrade(IBuyable item)
        {
            //TODO: Upgrade character.
            this.Upgrades.Add(item);
        }

        //Inventory holds apples and oshav.
        public void AddToInventory(ISellable item)
        {
            this.Bag.Add(item);
        }

        public void RemoveFromInventory(ISellable item)
        {
            this.Bag.Remove(item);
        }
        public override void Move(MatrixCoords newCoordinates)
        {
            this.Position = newCoordinates;
            GridDrawer.DrawObject(this);
        }

        public bool HasSong(Song checkedSong)
        {
            bool hasSong = false;
            if (this.WaitSongs.Contains(checkedSong))
            {
                hasSong = true;
            }

            return hasSong;
        }
    }
}
