using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_Breakdown : IBuildingCard, IEventCard
    {
        public void ExecuteActiveThreat()
        {
            Moral.LowerMoral();

            PutIntoEventDeck();
        }

        public void ExecuteCompletionEvent()
        {
            throw new NotImplementedException();
        }

        public void ExecuteFutureThreat()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 0;
        }

        public QuestionMark GetQuestionMark()
        {
            throw new NotImplementedException();
        }

        public bool IsCardTypeBook()
        {
            throw new NotImplementedException();
        }

        public void PutIntoEventDeck()
        {
            EventCard_Deck.RequestPut(this);
        }
        public override string ToString()
        {
            return "Breakdown;" + GetMaterialNumber();
        }
    }
}
