using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Wall : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Wall;
        }

        public int GetMaterialNumber()
        {
            return 0;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(0,0,0);
            return costs;
        }

        public bool IsBuildable()
        {
            if (InventionStorage.IsAvailable(Invention.Brick))
            {
                return true;
            }
            return false;
        }
        public void Research()
        {
            Wall.UpgradeWallBy(2);
        }
        public override string ToString()
        {
            return "Wall";
        }
    }
}
