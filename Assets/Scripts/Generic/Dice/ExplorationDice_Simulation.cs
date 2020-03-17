using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Generic.Dice
{
    public static class ExplorationDice_Simulation
    {
        public static SuccessDice RollSuccessDice()
        {
            Random r = new Random();
            var result = r.Next(1, 60) % 6;

            if(result == 3)
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

            if(result == 0 || result == 1 || result == 0)
            {
                return DamageDice.Damage;
            }
            else
            {
                return DamageDice.Nothing;
            }
        }

        public static CardDice RollCardDice()
        {
            Random r = new Random();
            var result = r.Next(1, 60) % 6;

            if(result == 0)
            {
                return CardDice.Nothing;
            }
            else
            {
                return CardDice.Card;
            }
        }
    }
}
