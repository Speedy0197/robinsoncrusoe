using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Brick : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Brick;
        }

        public int GetMaterialNumber()
        {
            return 22;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts();
            costs.AmountOfLeather = 0;
            costs.AmountOfWood = 0;
            return costs;
        }

        public bool IsBuildable()
        {
            if (TerrainStorage.GetValue(TerrainType.Hill))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Brick";
        }
    }
}
