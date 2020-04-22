using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Shield : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Shield;
        }

        public int GetMaterialNumber()
        {
            return 17;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(1,0,0);
            return costs;
        }

        public bool IsBuildable()
        {
            if (InventionStorage.IsAvailable(Invention.Rope))
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
            return "Shield";
        }
    }
}
