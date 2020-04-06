using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_Jaguar : IEventCard, ICard
    {
        public bool CanCompleteQuest()
        {
            if (WeaponPower.currentWeaponPower >= 2)
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
            Player.PartyActions.DamageAllPlayers(1);
        }

        private void ExecuteActiveThreat()
        {
            Player.PartyActions.DamageAllPlayers(1);
        }

        public void ExecuteSuccessEvent()
        {
            //Discard
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
            return 47;
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
            return "Jaguar";
        }
    }
}
