using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection
{
    public class BuildingCard_Tired : ICard, IBuildingCard
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
            Moral.LowerMoral();
        }

        private void ExecuteActiveThreat()
        {
            var active = Player.PartyActions.GetActiveCharacter();
            Characters.CharacterActions.HealCharacterBy(2, active);
        }

        public string GetCardDescription()
        {
            return "TODO";
        }

        public int GetMaterialNumber()
        {
            return 12;
        }

        public bool HasDiscardOption()
        {
            return true;
        }
        public override string ToString()
        {
            return "Tired";
        }
    }
}
