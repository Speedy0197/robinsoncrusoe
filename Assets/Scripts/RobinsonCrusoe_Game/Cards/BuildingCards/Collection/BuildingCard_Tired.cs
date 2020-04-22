using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_Tired : ICard, IBuildingCard
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
            var active = Player.PartyActions.ExecutingCharacter;
            Characters.CharacterActions.HealCharacterBy(2, active);
        }

        public string GetCardDescription()
        {
            if (eventNumber == 0)
            {
                return "Wähle aus: Lege diese Karte ab \r\n oder \r\n der Startspieler bekommt 2 Leben und \r\n diese Karte wird in den Eventstapel gemischt.";
            }
            else
            {
                return "Deine/Eure Moral sinkt um 1. \r\n Eine neue Karte wird gezogen.";
            }
        }

        public int GetMaterialNumber()
        {
            return 12;
        }

        public bool HasDiscardOption()
        {
            return true;
        }
        public override string ToString()
        {
            return "Tired";
        }
    }
}
