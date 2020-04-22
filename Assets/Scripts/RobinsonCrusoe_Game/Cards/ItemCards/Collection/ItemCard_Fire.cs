using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Fire : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Fire;
        }

        public int GetMaterialNumber()
        {
            return 25;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(0, 0, 0);
            return costs;
        }

        public bool IsBuildable()
        {
            if (TerrainStorage.GetValue(TerrainType.Mountain))
            {
                return true;
            }
            return false;
        }

        public void Research()
        {
            Wall.UpgradeWallBy(1);
        }

        public override string ToString()
        {
            return "Fire";
        }
    }
}
