using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class Phases
    {
        public static event EventHandler PhasesChanged;

        private static int PhasesState;
        public static void SetStartValue()
        {
            int start = 1;
            PhasesState = start;
            PhasesChanged?.Invoke(PhasesState, new EventArgs());
        }

        public static void NextPhase()
        {
            PhasesState += 1;
            if (PhasesState > 6)
            {
                //TO-DO End this round 
                PhasesState = 1;
            }
            PhasesChanged?.Invoke(PhasesState, new EventArgs());
        }
    }
}
