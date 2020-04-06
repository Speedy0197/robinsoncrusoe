using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_BodyOnTheBeach : IEventCard, ICard
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
            Moral.LowerMoral();
        }

        private void ExecuteActiveThreat()
        {
            Moral.LowerMoral();
        }

        public void ExecuteSuccessEvent()
        {
            var active = Player.PartyActions.GetActiveCharacter();
            Characters.CharacterActions.RaiseCharacterDeterminationBy(2, active);
        }

        public string GetCardDescription()
        {
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 10;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.None;
        }

        public bool IsCardTypeBook()
        {
            return true;
        }
        public override string ToString()
        {
            return "Body on the Beach";
        }

        public bool CanCompleteQuest()
        {
            if (InventionStorage.IsAvailable(Invention.Shovel))
            {
                return true;
            }
            return false;
        }

        public int GetActionCosts()
        {
            return 1;
        }

        public RessourceCosts GetRessourceCosts()
        {
            return new RessourceCosts(0, 0, 0);
        }
    }
}
