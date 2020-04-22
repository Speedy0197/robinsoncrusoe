using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_LackOfHope : IEventCard, ICard
    {
        public bool CanCompleteQuest()
        {
            return true;
        }

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
            Moral.LowerMoral();
        }

        private void ExecuteActiveThreat()
        {
            Player.PartyActions.SetNextActiveCharacter();
        }

        public void ExecuteSuccessEvent()
        {
            var active = Player.PartyActions.GetActiveCharacter();
            Characters.CharacterActions.RaiseCharacterDeterminationBy(1, active);
        }

        public int GetActionCosts()
        {
            return 1;
        }

        public string GetCardDescription()
        {
            return "Der nächste Spieler ist jetzt der Startspieler.";
        }

        public int GetMaterialNumber()
        {
            return 26;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.None;
        }

        public RessourceCosts GetRessourceCosts()
        {
            return new RessourceCosts(0, 0, 1);
        }

        public bool IsCardTypeBook()
        {
            return true;
        }
        public override string ToString()
        {
            return "Lack of Hope";
        }
        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
