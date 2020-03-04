using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public static class StageHandler
    {
        public static event EventHandler CurrentStageChanged;

        public static void ChangeStage(IStage stage)
        {
            CurrentStageChanged?.Invoke(stage, new EventArgs());
        }
    }
}
