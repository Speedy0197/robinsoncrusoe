using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class Eventphase : IStage
    {
        public void EndStage()
        {
            throw new NotImplementedException();
            //Change Stage
        }

        public void InitStage()
        {
            StageHandler.ChangeStage(this);
        }

        public void ProcessStage()
        {
            throw new NotImplementedException();
            //Draw eventcard

            //Activate its imediate effect

            //Push nearest danger card from stack and execute its effect
        }
    }
}
