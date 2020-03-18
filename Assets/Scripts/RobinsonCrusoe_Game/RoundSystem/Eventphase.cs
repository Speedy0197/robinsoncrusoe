using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
            StageHandler.ChangeStage(Stage.Event);
        }

        public void ProcessStage()
        {
            //Draw eventcard

            //Activate its imediate effect

            //Push nearest danger card from stack and execute its effect
        }
    }
}
