using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public static class InteractionManager
    {
        private const int GrannyTakeBagels = 2; //How many bagels a granny can take.
        public static void HouseInteraction(House house, MainCharacter wait)
        {
            if (wait.HasSong(house.SongRequest))
            {
                PlayerMP3.Play(house.SongRequest);
                RewardWait(wait, true);
            }
            else
	        {
                PlayerMP3.Play(wait.WaitSongs[wait.WaitSongs.Count - 1]);
                RewardWait(wait, false);
	        }
        }
        
        public static void RewardWait(MainCharacter wait, bool hasBonus) //If bonus = true, hero has the favorite song
        {
            wait.BagelCount += wait.WaitSongs.Count;

            if (hasBonus == true)
            {
                wait.BagelCount += House.Bonus;
            }
        }

        public static void GrannyInteraction(Grandmother granny, MainCharacter wait)
        {
            Song newSong = granny.GetSong;

            if (wait.HasSong(newSong) == false)
            {
                switch (granny.WantsSomething())
                {
                    case 1:
                        wait.BagelCount -= GrannyTakeBagels; break;
                    case 2:
                        wait.RemoveFromInventory(new Apple()); break;
                    case 3:
                        wait.RemoveFromInventory(new Oshav()); break;
                    default:
                        break;
                }
            }
        }
    }
}
