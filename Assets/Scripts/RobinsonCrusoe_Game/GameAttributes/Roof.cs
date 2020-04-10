using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Roof
    {
        public static event EventHandler RoofChanged;

        private static int RoofState;
        public static void SetStartValue(int start)
        {
            if (start < 0) start = 0;
            if (start > 4) start = 4;
            RoofState = start;
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }

        public static void UpgradeRoofBy(int value)
        {
            RoofState += value;
            if (RoofState > 4) RoofState = 4;
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }

        internal static void HalfValue()
        {
            int current = RoofState;
            int halfed = Convert.ToInt32(current / 2);

            RoofState = halfed;
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }

        public static void DowngradeRoofBy(int value)
        {
            RoofState -= value;
            if (RoofState < 0) RoofState = 0;
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }
    }
}
