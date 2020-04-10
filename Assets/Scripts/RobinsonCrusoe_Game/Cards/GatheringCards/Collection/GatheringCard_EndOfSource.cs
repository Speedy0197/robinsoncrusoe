using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards.Collection
{
    public class GatheringCard_EndOfSource : ICard, IGatheringCard
    {
        private int eventNumber = 0;
        public void ExecuteEvent()
        {
            if (eventNumber == 0)
            {
                ExecuteActiveThreat();
                eventNumber++;
            }
            else
            {
                ExecuteFutureThreat();
            }
        }

        private void ExecuteFutureThreat()
        {
            //Has none
        }

        private void ExecuteActiveThreat()
        {
            //TODO: end current source
        }

        public string GetCardDescription()
        {
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 22;
        }

        public bool HasDiscardOption()
        {
            return false;
        }
        public override string ToString()
        {
            return "End of Source";
        }
    }
}
