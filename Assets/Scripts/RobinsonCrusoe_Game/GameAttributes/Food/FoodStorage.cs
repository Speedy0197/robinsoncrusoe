using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food
{
    public static class FoodStorage
    {
        public static int Food { get; private set; }
        public static int PermanentFood { get; private set; }

        private const int minValue = 0;
        private const int maxValue = 100;

        public static event EventHandler AmountOfFoodChanged;
        public static event EventHandler AmountOfPermanentFoodChanged;

        public static void SetStartValue(int food, int permanentFood)
        {
            Food = food;
            PermanentFood = permanentFood;

            if (Food < minValue) Food = minValue;
            if (PermanentFood < minValue) PermanentFood = minValue;

            if (Food > maxValue) Food = maxValue;
            if (PermanentFood > maxValue) PermanentFood = maxValue;

            AmountOfFoodChanged?.Invoke(Food, new EventArgs());
            AmountOfPermanentFoodChanged?.Invoke(PermanentFood, new EventArgs());
        }

        public static void IncreaseFoodBy(int amount)
        {
            Food += amount;
            if (Food > maxValue) Food = maxValue;

            AmountOfFoodChanged?.Invoke(Food, new EventArgs());
        }

        public static void DecreaseFoodBy(int amount)
        {
            Food -= amount;
            if (Food < minValue) Food = minValue;

            AmountOfFoodChanged?.Invoke(Food, new EventArgs());
        }

        public static void IncreasePermantFoodBy(int amount)
        {
            PermanentFood += amount;
            if (PermanentFood > maxValue) PermanentFood = maxValue;

            AmountOfPermanentFoodChanged?.Invoke(PermanentFood, new EventArgs());
        }
        public static void DecreasePermantFoodBy(int amount)
        {
            PermanentFood -= amount;
            if (PermanentFood < minValue) PermanentFood = minValue;

            AmountOfPermanentFoodChanged?.Invoke(PermanentFood, new EventArgs());
        }

        public static void DiscardAll()
        {
            Food = 0;
            PermanentFood = 0;

            AmountOfFoodChanged?.Invoke(Food, new EventArgs());
            AmountOfPermanentFoodChanged?.Invoke(PermanentFood, new EventArgs());
        }

        public static void Consume(int amount)
        {
            if (amount < 0) amount = Math.Abs(amount);
            while(amount > 0)
            {
                if(Food > 0)
                {
                    DecreaseFoodBy(1);
                }
                else if(PermanentFood > 0)
                {
                    DecreasePermantFoodBy(1);
                }

                amount--;
            }
        }

        public static int GetTotal()
        {
            return Food + PermanentFood;
        }
    }
}
