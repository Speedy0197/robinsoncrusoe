using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_OldGrave : ICard, IExploringCard
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
            Characters.CharacterActions.LowerCharacterDeterminationBy(2, active);
        }

        private void ExecuteActiveThreat()
        {
            var active = Player.PartyActions.ExecutingCharacter;
            Characters.CharacterActions.LowerCharacterDeterminationBy(1, active);
        }

        public string GetCardDescription()
        {
            if (eventNumber == 0)
            {
                return "Du verlierst ein Entschlossenheitsplättchen. \r\n Diese Karte wird in den Eventstapel gemischt.";
            }
            else
            {
                return "Der Startspieler erhält 2 Entschlossenheitsplättchen. \r\n Eine neue Karte wird gezogen.";
            }
        }

        public int GetMaterialNumber()
        {
            return 12;
        }

        public bool HasDiscardOption()
        {
            return false;
        }
        public override string ToString()
        {
            return "Old Grave";
        }
    }
}
