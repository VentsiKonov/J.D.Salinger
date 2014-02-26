using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits.Engines_and_structures
{
    class InteractionManager
    {
        public void HouseInteraction(House house, MainCharacter wait)
        {
            if (wait.HasSong(house.FavoriteSong))
            {
                PlayerMP3.Play(house.FavoriteSong);
                RewardWait(wait, true);
            }
            else
	        {
                PlayerMP3.Play(wait.WaitSongs[WaitSongs.Count - 1]);
                RewardWait(wait, false);
	        }
        }
        
        public void RewardWait(MainCharacter wait, bool hasBonus) //If bonus = true, hero has the favorite song
        {
            wait.BagelCount += wait.Songs.Count;

            if (hasBonus == true)
            {
                wait.BagelCount += House.Bonus;
            }
        }
    }
}
