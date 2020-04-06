using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_Vertigo : IEventCard, ICard
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
            Player.PartyActions.LowerDeterminationOfPartyBy(1);
        }

        private void ExecuteActiveThreat()
        {
            var active = Player.PartyActions.GetActiveCharacter();
            active.CurrentNumberOfActions = 1;
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
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 27;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.None;
        }

        public RessourceCosts GetRessourceCosts()
        {
            return new RessourceCosts(0, 0, 0);
        }

        public bool IsCardTypeBook()
        {
            return true;
        }
        public override string ToString()
        {
            return "Vertigo";
        }
    }
}
