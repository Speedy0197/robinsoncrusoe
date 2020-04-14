using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards.Collection
{
    public class GatheringCard_WeatherBreakdown : IGatheringCard, ICard
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
            WeatherContainer.GlobalPlaceToken(WeatherToken.Storm);
        }

        private void ExecuteActiveThreat()
        {
            //Has none
        }

        public string GetCardDescription()
        {
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 0;
        }

        public bool HasDiscardOption()
        {
            return false;
        }

        public override string ToString()
        {
            return "Weather Breakdown";
        }
    }
}
