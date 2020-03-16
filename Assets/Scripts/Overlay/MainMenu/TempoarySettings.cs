using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Overlay.MainMenu
{
    public static class TempoarySettings
    {
        public static void Reset()
        {
            NumberOfPlayers = 0;

        }

        public static int NumberOfPlayers { get; set; }
    }
}
