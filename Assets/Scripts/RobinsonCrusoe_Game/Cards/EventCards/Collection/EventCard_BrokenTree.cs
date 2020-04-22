using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_BrokenTree : IEventCard, ICard
    {
        public bool CanCompleteQuest()
        {
            if (InventionStorage.IsAvailable(Invention.Rope))
            {
                return true;
            }
            return false;
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
        }

        private void ExecuteActiveThreat()
        {
            Player.PartyActions.DamageAllPlayers(1);
        }

        public void ExecuteSuccessEvent()
        {
            var active = Player.PartyActions.ExecutingCharacter;
            Characters.CharacterActions.RaiseCharacterDeterminationBy(1, active);

            Wood.IncreaseWoodBy(1);
        }

        public int GetActionCosts()
        {
            return 1;
        }

        public string GetCardDescription()
        {
            return "Jeder Spieler verliert 1 Leben.";
        }

        public int GetMaterialNumber()
        {
            return 63;
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
            return "Broken Tree";
        }
        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
