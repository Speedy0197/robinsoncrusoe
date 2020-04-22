using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_WildDog : ICard, IExploringCard
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
            if (FoodStorage.GetTotal() < 1)
            {
                var active = Player.PartyActions.ExecutingCharacter;
                Characters.CharacterActions.DamageCharacterBy(1, active);
            }
            else
            {
                FoodStorage.Consume(1);
            }
            WeaponPower.RaiseWeaponPowerBy(1);
        }

        private void ExecuteActiveThreat()
        {
            var active = Player.PartyActions.ExecutingCharacter;
            Characters.CharacterActions.DamageCharacterBy(1, active);
        }

        public string GetCardDescription()
        {
            return "Du verlierst 1 Leben. \r\n Diese Karte wird in den Eventstapel gemischt.";
        }

        public int GetMaterialNumber()
        {
            return 5;
        }

        public bool HasDiscardOption()
        {
            return false;
        }
        public override string ToString()
        {
            return "Wild Dog";
        }
    }
}
