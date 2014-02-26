using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class InteractionManager
    {
        private const int GrannyTakeBagels = 2; //How many bagels a granny can take.
        public bool HouseInteraction(House house, MainCharacter wait)
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
            return true;
        }
        
        public void RewardWait(MainCharacter wait, bool hasBonus) //If bonus = true, hero has the favorite song
        {
            wait.BagelCount += wait.WaitSongs.Count;

            if (hasBonus == true)
            {
                wait.BagelCount += House.Bonus;
            }
        }

        public bool GrannyInteraction(Grandmother granny, MainCharacter wait)
        {
            Song newSong = granny.GetSong;
           
            if (CheckPosition(granny, wait) && !wait.HasSong(newSong))
            {
                if (wait.CheckedForEnoughBagels(GrannyTakeBagels))
                {
                    wait.BagelCount -= GrannyTakeBagels;
                    wait.WaitSongs.Add(newSong);
                    return true;
                }
            }
            return false;
        }

        private bool CheckPosition(Grandmother granny, MainCharacter wait)
        {
            bool correctPosition = false;
 	        
            if ((granny.Position.Row == wait.Position.Row + 1 && granny.Position.Row == wait.Position.Row - 1)
                && (granny.Position.Col == wait.Position.Col || granny.Position.Col == wait.Position.Col + 1 ||
                    granny.Position.Col == wait.Position.Col - 1))
	        {
		        return true;
	        }
            if ((granny.Position.Col == wait.Position.Col + 1 && granny.Position.Col == wait.Position.Col - 1)
                && (granny.Position.Row == wait.Position.Row || granny.Position.Row == wait.Position.Row + 1 ||
                    granny.Position.Row == wait.Position.Row - 1))
	        {
		        return true;
	        }
            return false;
        }
       
    }
}
