using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Map : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Map;
        }

        public int GetMaterialNumber()
        {
            return 27;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(0,0,0);
            return costs;
        }

        public bool IsBuildable()
        {
            if (TerrainStorage.GetValue(IslandCards.TerrainType.River))
            {
                return true;
            }
            return false;
        }
        public void Research()
        {
            //Nothing
        }
        public override string ToString()
        {
            return "Map";
        }
    }
}
