using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Bow : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Bow;
        }

        public int GetMaterialNumber()
        {
            return 5;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(1,0,0);
            return costs;
        }

        public bool IsBuildable()
        {
            if(InventionStorage.IsAvailable(Invention.Knife) 
                && InventionStorage.IsAvailable(Invention.Rope))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Bow";
        }
    }
}
