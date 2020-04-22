using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_MemoryOfTheCruise : IEventCard, ICard
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
            Moral.LowerMoral();
        }

        public void ExecuteSuccessEvent()
        {
            Moral.RaiseMoral();

            var active = Player.PartyActions.ExecutingCharacter;
            Characters.CharacterActions.RaiseCharacterDeterminationBy(2, active);
        }

        public int GetActionCosts()
        {
            return 2;
        }

        public string GetCardDescription()
        {
            return "Deine/Eure Moral sinkt um 1.";
        }

        public int GetMaterialNumber()
        {
            return 54;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.Building;
        }

        public RessourceCosts GetRessourceCosts()
        {
            return new RessourceCosts(0, 0, 0);
        }

        public bool IsCardTypeBook()
        {
            return false;
        }
        public override string ToString()
        {
            return "Memories of the cruise";
        }
        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
