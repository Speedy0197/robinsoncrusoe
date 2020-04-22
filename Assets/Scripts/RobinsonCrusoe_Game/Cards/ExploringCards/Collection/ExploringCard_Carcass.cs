using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_Carcass : ICard, IExploringCard
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
            Player.PartyActions.DamageAllPlayers(1);
        }

        private void ExecuteActiveThreat()
        {
            FoodStorage.IncreaseFoodBy(2);
            Fur.IncreaseBy(1);
        }

        public string GetCardDescription()
        {
            if (eventNumber == 0)
            {
                return "Wähle aus: Lege diese Karte ab \r\n oder \r\n du/ihr bekommt 2 Nahrung und 1 Fell und \r\n diese Karte wird in den Eventstapel gemischt.";
            }
            else
            {
                return "Jeder Spieler verliert 1 Leben. \r\n Eine neue Karte wird gezogen.";
            }
        }

        public int GetMaterialNumber()
        {
            return 15;
        }

        public bool HasDiscardOption()
        {
            return true;          
        }
        public override string ToString()
        {
            return "Carcass"; 
        }
    }
}
