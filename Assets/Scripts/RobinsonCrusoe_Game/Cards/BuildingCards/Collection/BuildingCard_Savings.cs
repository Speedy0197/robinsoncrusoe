using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_Savings : ICard, IBuildingCard
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
            Moral.LowerMoral();
        }

        private void ExecuteActiveThreat()
        {
            Wood.IncreaseWoodBy(2);
        }

        public string GetCardDescription()
        {
            return "Du/Ihr bekommt 2 Hold. \r\n Diese Karte wird in den Eventstapel gemischt.";
        }

        public int GetMaterialNumber()
        {
            return 15;
        }
        public override string ToString()
        {
            return "Savings";
        }

        public bool HasDiscardOption()
        {
            return true;
        }
    }
}
