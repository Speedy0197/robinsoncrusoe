using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_ConstructionIsWeak : ICard, IBuildingCard
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
            Wall.HalfValue();
        }

        private void ExecuteActiveThreat()
        {
            //Has none
        }

        public string GetCardDescription()
        {
            return "Diese Karte wird in den Eventstapel gemischt.";
        }

        public int GetMaterialNumber()
        {
            return 4;
        }
        public override string ToString()
        {
            return "Construction is Weak";
        }

        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
