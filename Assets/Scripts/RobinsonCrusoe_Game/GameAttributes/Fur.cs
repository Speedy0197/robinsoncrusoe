using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Fur
    {
        public static event EventHandler AmountOFFurChanged;

        public static int currentAmountOfFur { get; private set; }

        public static void SetStartValue(int value)
        {
            if (value < 0) value = 0;
            currentAmountOfFur = value;
        }
        public static void IncreaseBy(int amount)
        {
            currentAmountOfFur += amount;

            AmountOFFurChanged?.Invoke(currentAmountOfFur, new EventArgs());
        }
        public static void DecreaseBy(int amount)
        {
            currentAmountOfFur -= amount;
            if (currentAmountOfFur < 0) currentAmountOfFur = 0;

            AmountOFFurChanged?.Invoke(currentAmountOfFur, new EventArgs());
        }

        public static void DiscardAll()
        {
            currentAmountOfFur = 0;

            AmountOFFurChanged?.Invoke(currentAmountOfFur, new EventArgs());
        }
    }
}
