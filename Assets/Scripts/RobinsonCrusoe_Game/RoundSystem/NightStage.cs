﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class NightStage : IStage
    {
        public void EndStage()
        {
            throw new NotImplementedException();
            //Change to next stage
        }

        public void InitStage()
        {
            StageHandler.ChangeStage(Stage.Night);
        }

        public void ProcessStage()
        {
            
        }
    }
}
