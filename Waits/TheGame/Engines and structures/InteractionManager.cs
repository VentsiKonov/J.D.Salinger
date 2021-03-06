﻿using System;
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
            if (!CheckPosition(granny, wait))
            {
                return false;
            }

            Song newSong = granny.GetSong;
           
            if (!wait.HasSong(newSong))
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
        
        public static bool MarketInterraction(MarketPlace market, MainCharacter wait)
        {
            if (!CheckPosition(market, wait))
            {
                return false;
            }

            int moneyInObjects = 0;
            bool successfulTransaction = false;
            var listItems = wait.Bag.FindAll((i) => i.GetType().Name != "Rakia");
            for (int i = 0; i < listItems.Count; i++)
            {
                moneyInObjects += listItems[i].Price;
                wait.Bag.Remove(listItems[i]);   
            }

            if (!wait.Upgrades.Contains(Gega.GegaInstance))
            {
                if (moneyInObjects >= Gega.GegaInstance.Price)
                {
                    wait.Upgrades.Add(Gega.GegaInstance);
                    if(moneyInObjects > Gega.GegaInstance.Price)
                    {
                        wait.BagelCount += moneyInObjects - Gega.GegaInstance.Price;
                    }
                    return true;
                }
            }

            if (!wait.Upgrades.Contains(SpeedBoots.BootsInstance))
            {
                if (moneyInObjects >= SpeedBoots.BootsInstance.Price)
                {
                    wait.Upgrades.Add(SpeedBoots.BootsInstance);
                    if (moneyInObjects > SpeedBoots.BootsInstance.Price)
                    {
                        wait.BagelCount += moneyInObjects - SpeedBoots.BootsInstance.Price;
                    }
                    return true;
                }
            }

            if (successfulTransaction)
            {
                wait.BagelCount += moneyInObjects;
                return true;
            }
            return false;
        }

    }
}
