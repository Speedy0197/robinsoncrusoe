using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_ColdWind : ICard, IExploringCard
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
            WeatherContainer.GlobalPlaceToken(WeatherToken.Snow);
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
                return "Ein Schneetoken wird auf das Wetterfeld gelegt. \r\n Eine neue Karte wird gezogen.";
            }
        }

        public int GetMaterialNumber()
        {
            return 16;
        }

        public bool HasDiscardOption()
        {
            return false;
        }
        public override string ToString()
        {
            return "Cold Wind";
        }
    }
}
