using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class EventCard_RavishingWindstorm : IEventCard, ICard
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
            //Nothing happens
        }

        private void ExecuteActiveThreat()
        {
            if(WeaponPower.currentWeaponPower >= 2)
            {
                WeaponPower.LowerWeaponPowerBy(2);
            }
        }

        public void ExecuteSuccessEvent()
        {
            WeaponPower.RaiseWeaponPowerBy(1);

            var active = Player.PartyActions.ExecutingCharacter;
            Characters.CharacterActions.RaiseCharacterDeterminationBy(1, active);
        }

        public int GetActionCosts()
        {
            return 1;
        }

        public string GetCardDescription()
        {
            return "Falls möglich wird die Waffenstärke um 2 gesenkt.";
        }

        public int GetMaterialNumber()
        {
            return 52;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.Exploring;
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
            return "Ravishing Windstorm";
        }
        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
