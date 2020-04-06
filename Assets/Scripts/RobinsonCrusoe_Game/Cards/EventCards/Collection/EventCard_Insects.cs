using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_Insects : IEventCard, ICard
    {
        public bool CanCompleteQuest()
        {
            if (InventionStorage.IsAvailable(Invention.Fire))
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
            if (Wood.currentAmountOfWood >= 1)
            {
                Wood.DecreaseWoodBy(1);
            }
        }

        private void ExecuteActiveThreat()
        {
            if(Wood.currentAmountOfWood >= 1)
            {
                Wood.DecreaseWoodBy(1);
            }
        }

        public void ExecuteSuccessEvent()
        {
            var active = PartyActions.GetActiveCharacter();
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
            return 3;
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
            return "Insects";
        }
    }
}
