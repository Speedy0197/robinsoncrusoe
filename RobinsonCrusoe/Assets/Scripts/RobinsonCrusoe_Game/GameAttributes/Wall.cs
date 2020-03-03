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

        private static int WallState;

        public static void SetStartState(int start)
        {
            if (start < 0) start = 0;
            if (start > 4) start = 4;
            WallState = start;
            WallStateChanged?.Invoke(WallState, new EventArgs());
        }

        public static void UpgradeWallBy(int value)
        {
            WallState += value;
            if (WallState > 4) WallState = 4;
            WallStateChanged?.Invoke(WallState, new EventArgs());
        }

        public static void DowngradeWallBy(int value)
        {
            WallState -= value;
            if (WallState < 0) WallState = 0;
            WallStateChanged?.Invoke(WallState, new EventArgs());
        }
    }
}
