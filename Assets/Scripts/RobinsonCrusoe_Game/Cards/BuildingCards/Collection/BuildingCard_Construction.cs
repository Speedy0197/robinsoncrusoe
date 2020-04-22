using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_Construction : ICard, IBuildingCard
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
            Wall.UpgradeWallBy(1);
        }

        private void ExecuteActiveThreat()
        {
            //Has none
        }

        public string GetCardDescription()
        {
            if (eventNumber == 0)
            {
                return "Diese Karte wird in den Eventstapel gemischt.";
            }
            else
            {
                return "Falls ein Unterschlupf vorhanden ist wird die Palisade um 1 erhöht. \r\n Eine neue Karte wird gezogen.";
            }
        }

        public int GetMaterialNumber()
        {
            return 22;
        }
        public override string ToString()
        {
            return "Construction";
        }

        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
