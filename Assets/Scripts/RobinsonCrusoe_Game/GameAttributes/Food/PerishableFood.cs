using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food
{
    public static class PerishableFood
    {
        public static event EventHandler AmountOfPerishableFoodChanged;

        private static int currentAmountOfPerishableFood;
        private const int maxValue = 1000;
        private const int minValue = 0;

        public static void SetStartValue(int value)
        {
            currentAmountOfPerishableFood = value;
            if (currentAmountOfPerishableFood < minValue) currentAmountOfPerishableFood = minValue;
            if (currentAmountOfPerishableFood > maxValue) currentAmountOfPerishableFood = maxValue;

            AmountOfPerishableFoodChanged?.Invoke(currentAmountOfPerishableFood, new EventArgs());
        }

        public static void IncreaseBy(int value)
        {
            currentAmountOfPerishableFood += value;
            if (currentAmountOfPerishableFood > maxValue) currentAmountOfPerishableFood = maxValue;

            AmountOfPerishableFoodChanged?.Invoke(currentAmountOfPerishableFood, new EventArgs());
        }

        public static void DecreaseBy(int value)
        {
            currentAmountOfPerishableFood -= value;
            if (currentAmountOfPerishableFood < minValue) currentAmountOfPerishableFood = minValue;

            AmountOfPerishableFoodChanged?.Invoke(currentAmountOfPerishableFood, new EventArgs());
        }

        public static void Perish()
        {
            currentAmountOfPerishableFood = minValue;

            AmountOfPerishableFoodChanged?.Invoke(currentAmountOfPerishableFood, new EventArgs());
        }

        public static void DiscardAll()
        {
            currentAmountOfPerishableFood = 0;

            AmountOfPerishableFoodChanged?.Invoke(currentAmountOfPerishableFood, new EventArgs());
        }
    }
}
