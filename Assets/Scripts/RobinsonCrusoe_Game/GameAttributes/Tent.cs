using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Tent
    {
        public static TentStatus Status { get; set; } = TentStatus.Fireplace;
    }

    public enum TentStatus
    {
        Fireplace,
        Shelter,
    }
}
