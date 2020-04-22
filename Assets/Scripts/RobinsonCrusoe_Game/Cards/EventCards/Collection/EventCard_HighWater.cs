using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_HighWater : IEventCard, ICard
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
            Wood.DiscardAll();
            UnperishableFood.DiscardAll();
            PerishableFood.DiscardAll();
            Fur.DiscardAll();

            //TODO: skip production phase during this turn
        }

        private void ExecuteActiveThreat()
        {
            ExploringCard_Deck.GlobalSetQuestionMarkOnDeck();
        }

        public void ExecuteSuccessEvent()
        {
            var active = Player.PartyActions.GetActiveCharacter();
            Characters.CharacterActions.RaiseCharacterDeterminationBy(2, active);
        }

        public int GetActionCosts()
        {
            return 1;
        }

        public string GetCardDescription()
        {
            return "Ein grünes Fragezeichen wird zusätzlich platziert.";
        }

        public int GetMaterialNumber()
        {
            return 42;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.Gathering;
        }

        public RessourceCosts GetRessourceCosts()
        {
            return new RessourceCosts(1, 0, 0);
        }

        public bool IsCardTypeBook()
        {
            return false;
        }
        public override string ToString()
        {
            return "High Water";
        }
        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
