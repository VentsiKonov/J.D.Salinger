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
        public static bool HouseInteraction(House house, MainCharacter wait)
        {
            if (!CheckPosition(house, wait))
            {
                return false;
            }

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
        
        public static void RewardWait(MainCharacter wait, bool hasBonus) //If bonus = true, hero has the favorite song
        {
            wait.BagelCount += wait.WaitSongs.Count;

            if (hasBonus == true)
            {
                wait.BagelCount += House.Bonus;
            }
        }

        public static bool GrannyInteraction(Grandmother granny, MainCharacter wait)
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

        private static bool CheckPosition(IRenderable item, MainCharacter wait)
        {
            if ((item.Position.Row == wait.Position.Row + 1 || item.Position.Row == wait.Position.Row - 1)
                && (item.Position.Col == wait.Position.Col || item.Position.Col == wait.Position.Col + 1 ||
                    item.Position.Col == wait.Position.Col - 1))
	        {
		        return true;
	        }
            if ((item.Position.Col == wait.Position.Col + 1 || item.Position.Col == wait.Position.Col - 1)
                && (item.Position.Row == wait.Position.Row || item.Position.Row == wait.Position.Row + 1 ||
                    item.Position.Row == wait.Position.Row - 1))
	        {
		        return true;
	        }
            return false;
        }
       
    }
}
