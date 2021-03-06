﻿using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Wall
    {
        public static event EventHandler WallStateChanged;

        public static int WallState { get; private set; }

        public static void SetStartState(int start)
        {
            if (start < 0) start = 0;
            if (start > 4) start = 4;
            WallState = start;
            WallStateChanged?.Invoke(WallState, new EventArgs());
        }

        public static void UpgradeWallBy(int value)
        {
            if (Tent.Status == TentStatus.Shelter)
            {
                WallState += value;
                if (WallState > 4) WallState = 4;
                WallStateChanged?.Invoke(WallState, new EventArgs());
            }
        }

        internal static void HalfValue_Floor()
        {
            double current = WallState;
            double halfed = current / 2;

            double floored_half = Math.Floor(halfed);
            int int_half = Convert.ToInt32(floored_half);

            WallState = int_half;
            WallStateChanged?.Invoke(WallState, new EventArgs());
        }
        internal static void HalfValue_Ceiling()
        {
            double current = WallState;
            double halfed = current / 2;

            double ceiling_half = Math.Ceiling(halfed);
            int int_half = Convert.ToInt32(ceiling_half);

            WallState = int_half;
            WallStateChanged?.Invoke(WallState, new EventArgs());
        }

        public static void DowngradeWallBy(int value)
        {
            WallState -= value;
            if (WallState < 0)
            {
                int dmg = Math.Abs(WallState);
                PartyActions.DamageAllPlayers(dmg);

                WallState = 0;
            }
            WallStateChanged?.Invoke(WallState, new EventArgs());
        }
    }
}
