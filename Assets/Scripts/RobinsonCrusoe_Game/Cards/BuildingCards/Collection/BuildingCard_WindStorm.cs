using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_WindStorm : ICard, IBuildingCard
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
            Wall.DowngradeWallBy(1);
        }

        public string GetCardDescription()
        {
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 2;
        }

        public bool HasDiscardOption()
        {
            return false;
        }
        public override string ToString()
        {
            return "Wind-Storm";
        }
    }
}
