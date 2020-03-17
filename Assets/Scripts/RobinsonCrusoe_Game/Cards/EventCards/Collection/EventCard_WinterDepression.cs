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
    public class EventCard_WinterDepression : IEventCard
    {
        public void ExecuteActiveThreat()
        {
            Moral.LowerMoral();
        }

        public void ExecuteCompletionEvent()
        {
            var character = PartyActions.GetActiveCharacter();
            CharacterActions.LowerCharacterDeterminationBy(1, character);
        }

        public void ExecuteFutureThreat()
        {
            PartyActions.LowerDeterminationOfPartyBy(1);
        }

        public string GetDescriptionText()
        {
            throw new NotImplementedException();
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
            return "WinterDepression;" + GetMaterialNumber();
        }
    }
}
