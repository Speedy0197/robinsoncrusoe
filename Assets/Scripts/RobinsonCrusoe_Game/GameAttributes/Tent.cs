using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Tent
    {
        public static TentStatus Status { get; private set; } = TentStatus.Fireplace;

        public static void ChangeTentSatus(TentStatus newStatus)
        {
            Status = newStatus;
            OnTentStatusChanged?.Invoke(null, new EventArgs());
        }
        public static event EventHandler OnTentStatusChanged;
    }

    public enum TentStatus
    {
        Fireplace,
        NaturalShelter,
        Shelter,
    }
}
