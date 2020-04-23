using Assets.Scripts.Player;
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

        public static int RoofState { get; private set; }
        public static void SetStartValue(int start)
        {
            if (start < 0) start = 0;
            if (start > 4) start = 4;
            RoofState = start;
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }

        public static void UpgradeRoofBy(int value)
        {
            if (Tent.Status == TentStatus.Shelter)
            {
                RoofState += value;
                if (RoofState > 4) RoofState = 4;
                RoofChanged?.Invoke(RoofState, new EventArgs());
            }
        }

        internal static void HalfValue_Floor()
        {
            double current = RoofState;
            double halfed = current / 2;

            double floored_half = Math.Floor(halfed);
            int int_half = Convert.ToInt32(floored_half);

            RoofState = int_half;
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }
        internal static void HalfValue_Ceiling()
        {
            double current = RoofState;
            double halfed = current / 2;

            double ceiling_half = Math.Ceiling(halfed);
            int int_half = Convert.ToInt32(ceiling_half);

            RoofState = int_half;
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }

        public static void DowngradeRoofBy(int value)
        {
            RoofState -= value;
            if (RoofState < 0)
            {
                int dmg = Math.Abs(RoofState);
                PartyActions.DamageAllPlayers(dmg);

                RoofState = 0;
            }
            RoofChanged?.Invoke(RoofState, new EventArgs());
        }
    }
}
