using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards.Collection
{
    public class GatheringCard_Mushrooms : ICard, IGatheringCard
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
            if (!InventionStorage.IsAvailable(Invention.Cure))
            {
                Player.PartyActions.DamageAllPlayers(1);
            }
        }

        private void ExecuteActiveThreat()
        {
            var numberOfPlayers = Player.PartyActions.GetNumberOfPlayers();
            PerishableFood.IncreaseBy(numberOfPlayers);
        }

        public string GetCardDescription()
        {
            return "Du/Ihr erhaltet 1 Nahrung pro Spieler. \r\n Diese Karte wird in den Eventstapel gemischt.";
        }

        public int GetMaterialNumber()
        {
            return 19;
        }

        public bool HasDiscardOption()
        {
            return true;
        }
        public override string ToString()
        {
            return "Mushrooms";
        }
    }
}
