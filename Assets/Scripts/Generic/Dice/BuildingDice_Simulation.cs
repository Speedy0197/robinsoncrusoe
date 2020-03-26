﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Generic.Dice
{
    public static class BuildingDice_Simulation
    {
        public static SuccessDice RollSuccessDice()
        {
            Random r = new Random();
            var result = r.Next(1, 60) % 6;

            if(result == 2 || result == 3)
            {
                return SuccessDice.Determination;
            }
            else
            {
                return SuccessDice.Success;
            }
        }

        public static DamageDice RollDamageDice()
        {
            Random r = new Random();
            var result = r.Next(1, 60) % 6;

            if(result == 3 || result == 4)
            {
                return DamageDice.Nothing;
            }
            else
            {
                return DamageDice.Damage;
            }
        }

        public static CardDice RollCardDice()
        {
            Random r = new Random();
            var result = r.Next(1, 60) % 6;

            if(result == 1 || result == 3 || result == 4)
            {
                return CardDice.Card;
            }
            else
            {
                return CardDice.Nothing;
            }
        }
    }
}