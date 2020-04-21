using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food
{
    public static class UnperishableFood
    {
        public static event EventHandler AmountOfUnperishableFoodChanged;

        public static int currentAmountOfUnperishableFood { get; private set; }
        private const int minValue = 0;
        private const int maxValue = 1000;

        public static void SetStartValue(int value)
        {
            currentAmountOfUnperishableFood = value;
            if (currentAmountOfUnperishableFood < minValue) currentAmountOfUnperishableFood = minValue;
            if (currentAmountOfUnperishableFood > maxValue) currentAmountOfUnperishableFood = maxValue;

            AmountOfUnperishableFoodChanged?.Invoke(currentAmountOfUnperishableFood, new EventArgs());
        }

        public static void IncreaseBy(int value)
        {
            currentAmountOfUnperishableFood += value;
            if (currentAmountOfUnperishableFood > maxValue) currentAmountOfUnperishableFood = maxValue;

            AmountOfUnperishableFoodChanged?.Invoke(currentAmountOfUnperishableFood, new EventArgs());
        }

        public static void DecreaseBy(int value)
        {
            currentAmountOfUnperishableFood -= value;
            if (currentAmountOfUnperishableFood < minValue) currentAmountOfUnperishableFood = minValue;

            AmountOfUnperishableFoodChanged?.Invoke(currentAmountOfUnperishableFood, new EventArgs());
        }

        public static void DiscardAll()
        {
            currentAmountOfUnperishableFood = 0;

            AmountOfUnperishableFoodChanged?.Invoke(currentAmountOfUnperishableFood, new EventArgs());
        }
    }
}
