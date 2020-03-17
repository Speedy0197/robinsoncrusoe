using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class Wreckage_CaptainsChest : IEventCard
    {
        public void ExecuteActiveThreat()
        {
            throw new NotImplementedException();
        }

        public void ExecuteCompletionEvent()
        {
            throw new NotImplementedException();
        }

        public void ExecuteFutureThreat()
        {
            throw new NotImplementedException();
        }

        public string GetDescriptionText()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 2;
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
            return "Captain'sChest;" + GetMaterialNumber();
        }
    }
}
