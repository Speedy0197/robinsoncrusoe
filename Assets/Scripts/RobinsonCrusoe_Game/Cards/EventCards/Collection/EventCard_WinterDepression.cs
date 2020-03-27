using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_WinterDepression : ICard, IEventCard
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
            //TODO: this method is bugged
            Debug.Log("WinterDepression - Future Threat");
            //PartyActions.LowerDeterminationOfPartyBy(1);
        }

        private void ExecuteActiveThreat()
        {
            Moral.LowerMoral();
        }

        public void ExecuteSuccessEvent()
        {
            var character = PartyActions.GetActiveCharacter();
            CharacterActions.LowerCharacterDeterminationBy(1, character);
        }

        public int GetMaterialNumber()
        {
            return 4;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.None;
        }

        public bool IsCardTypeBook()
        {
            return false;
        }

        public override string ToString()
        {
            return "Winter Depression";
        }

        public string GetCardDescription()
        {
            return "Description";
        }
    }
}
