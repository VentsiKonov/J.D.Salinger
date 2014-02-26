﻿using System;
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
        
        public void RewardWait(MainCharacter wait, bool hasBonus) //If bonus = true, hero has the favorite song
        {
            wait.BagelCount += wait.WaitSongs.Count;

            if (hasBonus == true)
            {
                wait.BagelCount += House.Bonus;
            }
        }

        public void GrannyInteraction(Grandmother granny, MainCharacter wait)
        {
            Song newSong = granny.GetSong;

            if (wait.HasSong(newSong) == false)
            {
                switch (granny.WantsSomething())
                {
                    case 1:
                        wait.AddToInventory(new Apple()); break;
                    case 2:
                        wait.AddToInventory(new Oshav()); break;
                    default:
                        break;
                }
            }
        }
    }
}
