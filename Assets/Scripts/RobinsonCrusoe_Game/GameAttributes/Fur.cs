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

        private static int currentAmountOfFur;

        public static void SetStartValue(int value)
        {
            if (value < 0) value = 0;
            currentAmountOfFur = value;
        }

        public static void ChangeFurValueBy(int amount)
        {
            currentAmountOfFur += amount;
            if (currentAmountOfFur < 0) currentAmountOfFur = 0;
            //Max value needed?

            AmountOFFurChanged?.Invoke(currentAmountOfFur, new EventArgs());
        }

    }
}
