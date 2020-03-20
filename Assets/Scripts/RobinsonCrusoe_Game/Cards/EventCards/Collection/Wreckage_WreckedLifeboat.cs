using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class Wreckage_WreckedLifeboat : ICard, IEventCard
    {
        public void ExecuteEvent()
        {
            //Has none
        }

        public void ExecuteSuccessEvent()
        {
            throw new NotImplementedException();
        }

        public string GetCardDescription()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 1;
        }

        public QuestionMark GetQuestionMark()
        {
            throw new NotImplementedException();
        }

        public bool IsCardTypeBook()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Wrecked Lifeboat";
        }
    }
}
