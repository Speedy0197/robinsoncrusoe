using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards.Collection
{
    public class GatheringCard_WeatherBreakdown : IGatheringCard, ICard
    {
        public void ExecuteEvent()
        {
            throw new NotImplementedException();
        }

        public string GetCardDescription()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 0;
        }
        public override string ToString()
        {
            return "Weather Breakdown";
        }
    }
}
