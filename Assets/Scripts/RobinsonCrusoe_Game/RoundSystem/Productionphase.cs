using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.RoundSystem
{
    class Productionphase: IStage
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
            //Get Position of Tent //Mock
            int postion = 0;

            if (postion == 0)
            {
                //FoodStorage.Instance.increaseFood();
            }
        }
    }
}
