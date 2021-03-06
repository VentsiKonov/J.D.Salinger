﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    class Pub : Building, IRenderable
    {
        public Pub(MatrixCoords position)
            : base("Pub", position)
        {
            // empty
        }
        public bool CheckForBagels(MainCharacter hero)
        {
            if (hero.BagelCount >= 20)
            {
                return true;
            }
            return false;
        }

        public bool CanSell(MainCharacter wait)
        {
            if (wait.BagIsFull() == true || CheckForBagels(wait) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string SellRakia(MainCharacter hero)
        {
            if (CheckForBagels(hero))
            {
                if (hero.BagIsFull())
                {
                    return "Your bag is full.";
                }
                else
                {
                    //Choose rakia type method.
                    //hero.Bag.Add();
                    return "Sell completed!";
                }
            }
            return "You don't have enough bagels to buy rakia.";
        }

    }
}
