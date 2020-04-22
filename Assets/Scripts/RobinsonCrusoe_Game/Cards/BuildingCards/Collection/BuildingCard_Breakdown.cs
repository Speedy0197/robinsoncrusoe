using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_Breakdown : IBuildingCard, ICard
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
            var active = Player.PartyActions.GetActiveCharacter();
            Characters.CharacterActions.RaiseCharacterDeterminationBy(2, active);
        }

        private void ExecuteActiveThreat()
        {
            Moral.LowerMoral();
        }

        public string GetCardDescription()
        {
            if (eventNumber == 0)
            {
                return "Deine/Eure Moral sinkt um 1. \r\n Diese Karte wird in den Eventstapel gemischt.";
            }
            else
            {
                return "Der Startspieler erhält 2 Entschlossenheit. \r\n Eine neue Karte wird gezogen.";
            }
        }

        public int GetMaterialNumber()
        {
            return 0;
        }
        public override string ToString()
        {
            return "Breakdown";
        }

        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
