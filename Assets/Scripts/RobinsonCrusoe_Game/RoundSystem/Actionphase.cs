using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class Actionphase : IStage
    {

        public void EndStage()
        {
            throw new NotImplementedException();
            //Skip to next phase
        }

        public void InitStage()
        {
            StageHandler.ChangeStage(this);
        }

        public void ProcessStage()
        {
            throw new NotImplementedException();
        }
    }
}
