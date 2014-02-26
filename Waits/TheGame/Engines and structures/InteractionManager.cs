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
            }
            else
	        {
                PlayerMP3.Play(wait.HeroSongs[HeroSongs.Count - 1]);
	        }
        }
        
        public RewardHero()

    }
}
