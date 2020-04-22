using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_Bamboo : ICard, IExploringCard
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
            Roof.DowngradeRoofBy(1);

            //TODO: has option to choose between roof and pallisade
        }

        private void ExecuteActiveThreat()
        {
            Wood.IncreaseWoodBy(2);
        }

        public string GetCardDescription()
        {
            if (eventNumber == 0)
            {
                return "Wähle aus: Lege diese Karte ab \r\n oder \r\n du/Ihr bekommt 2 Holz und \r\n diese Karte wird in den Eventstapel gemischt.";
            }
            else
            {
                return "Deine/Eure Dachstärke sinkt um 1.";
            }
        }

        public int GetMaterialNumber()
        {
            return 14;
        }

        public bool HasDiscardOption()
        {
            return true;
        }
        public override string ToString()
        {
            return "Bamboo";
        }
    }
}
