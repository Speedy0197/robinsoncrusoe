using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class Wreckage_WreckedLifeboat : ICard, IEventCard
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
            //TODO: card has an option for only one action
            Wood.IncreaseWoodBy(2);
        }

        public int GetActionCosts()
        {
            return 2;
        }

        public string GetCardDescription()
        {
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 1;
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
            return "Wrecked Lifeboat";
        }
    }
}
