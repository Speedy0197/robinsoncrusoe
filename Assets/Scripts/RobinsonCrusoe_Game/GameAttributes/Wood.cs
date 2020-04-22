using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Wood
    {
        /// <summary>
        /// Is fired when the current amount of wood changes, the sender objekt is the Amount of Wood as int value
        /// </summary>
        public static event EventHandler AmountOfWoodChanged;

        public static int currentAmountOfWood { get; private set; }
        private const int maxValue = 1000;
        private const int minValue = 0;

        public static void SetStartValue(int value)
        {
            if (value < minValue) value = minValue;
            currentAmountOfWood = value;

            AmountOfWoodChanged?.Invoke(currentAmountOfWood, new EventArgs());
        }

        public static void IncreaseWoodBy(int value)
        {
            currentAmountOfWood += value;
            if (currentAmountOfWood > maxValue) currentAmountOfWood = maxValue;

            AmountOfWoodChanged?.Invoke(currentAmountOfWood, new EventArgs());
        }

        public static void DecreaseWoodBy(int value)
        {
            currentAmountOfWood -= value;
            if (currentAmountOfWood < minValue)
            {
                int dmg = Math.Abs(currentAmountOfWood);
                PartyActions.DamageAllPlayers(dmg);

                currentAmountOfWood = minValue;
            }

            AmountOfWoodChanged?.Invoke(currentAmountOfWood, new EventArgs());
        }

        public static void DiscardAll()
        {
            currentAmountOfWood = 0;
            AmountOfWoodChanged?.Invoke(currentAmountOfWood, new EventArgs());
        }
    }
}
