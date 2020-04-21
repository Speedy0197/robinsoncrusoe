using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_DevastatingHurricane : IEventCard, ICard
    {
        public bool CanCompleteQuest()
        {
            return true;
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
            Wall.DowngradeWallBy(1);
            //TODO: implement choice between wall and weapons
        }

        private void ExecuteActiveThreat()
        {
            int state = Wall.WallState;
            double half = state / 2;
            state = Convert.ToInt32(half);

            Wall.DowngradeWallBy(state);

            //TODO: implement choice between wall and weapons
        }

        public void ExecuteSuccessEvent()
        {
            Wall.UpgradeWallBy(1);
            //TODO: implement choice between wall and weapons
        }

        public int GetActionCosts()
        {
            return 1;
        }

        public string GetCardDescription()
        {
            return "Dein/Euer Wall wird halbiert(abgerundet).";
        }

        public int GetMaterialNumber()
        {
            return 51;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.Gathering;
        }

        public RessourceCosts GetRessourceCosts()
        {
            return new RessourceCosts(1, 0, 0);
        }

        public bool IsCardTypeBook()
        {
            return false;
        }
        public override string ToString()
        {
            return "Devastating Hurricane";
        }
    }
}
