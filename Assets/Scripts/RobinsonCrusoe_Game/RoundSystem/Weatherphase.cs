using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    public class Weatherphase : IStage
    {
        public void EndStage()
        {
            throw new NotImplementedException();
            //Change to next stage
        }

        public void InitStage()
        {
            StageHandler.ChangeStage(Stage.Weather);
        }

        public void ProcessStage()
        {
            throw new NotImplementedException();
            //if hasToRollWeatherDice 
            //  roll dice
            //  execute the effects
        }
    }
}
