using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class Wreckage_CaptainsChest : ICard, IEventCard
    {
        public bool CanCompleteQuest()
        {
            return true;
        }

        public void ExecuteEvent()
        {
            //Has none
        }

        public void ExecuteSuccessEvent()
        {
            //TODO: Card has an option for two actions
            Wood.IncreaseWoodBy(1);
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
            return 2;
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
            return false;
        }
        public override string ToString()
        {
            return "Captain'sChest";
        }
        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
