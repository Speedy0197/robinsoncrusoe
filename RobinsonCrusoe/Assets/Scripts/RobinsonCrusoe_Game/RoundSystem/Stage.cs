using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public enum Stage
    {
        Eventphase,
        Moralphase,
        Productionphase,
        Actionphase,
        Weatherphase,
        Nightphase,
    }

    public static class StageHandler
    {
        public static Stage CurrentStage = Stage.Eventphase;

        public static void ChangePhase()
        {
                
        }
    }
}
