using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards.Collection
{
    public class GatheringCard_NiceSurprise : ICard, IGatheringCard
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
            Roof.HalfValue_Floor();
        }

        private void ExecuteActiveThreat()
        {
            Wood.IncreaseWoodBy(3);
        }

        public string GetCardDescription()
        {
            if (eventNumber == 0)
            {
                return "Wähle aus: Lege diese Karte ab \r\n oder \r\n du/Ihr erhaltet 3 Holz und\r\n diese Karte wird in den Eventstapel gemischt.";
            }
            else
            {
                return "Die Dachstärke wird halbiert(abgerundet).\r\n Eine neue Karte wird gezogen.";
            }
        }

        public int GetMaterialNumber()
        {
            return 8;
        }

        public bool HasDiscardOption()
        {
            return true;
        }
        public override string ToString()
        {
            return "Nice Surprise";
        }
    }
}
