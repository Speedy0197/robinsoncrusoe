using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_TheresSomethingInTheAir : ICard, IExploringCard
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
            //TODO: put ? on explore deck
        }

        private void ExecuteActiveThreat()
        {
            //TODO: put ? on explore deck
        }

        public string GetCardDescription()
        {
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 19;
        }

        public bool HasDiscardOption()
        {
            return false;
        }
        public override string ToString()
        {
            return "There's something in the Air";
        }
    }
}
