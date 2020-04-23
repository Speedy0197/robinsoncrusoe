using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class DifficultyHandler
    {
        /// <summary>
        /// 0 = Newbie
        /// 1 = Einfach
        /// 2 = Mittel
        /// 3 = Schwer
        /// 4 = Profi
        /// </summary>
        public static int Value { get; set; } = 0;
    }
}
