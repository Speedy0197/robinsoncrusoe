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
            WeatherContainer.GlobalPlaceToken(WeatherToken.Storm);
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
                return "Ein Sturmtoken wird auf das Wetterfeld gelegt.\r\n Eine neue Karte wird gezogen.";
            }
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
