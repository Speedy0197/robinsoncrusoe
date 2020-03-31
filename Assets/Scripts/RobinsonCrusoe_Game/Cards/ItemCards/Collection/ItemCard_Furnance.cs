using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Furnance : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Furnance;
        }

        public int GetMaterialNumber()
        {
            return 10;
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
            if (InventionStorage.IsAvailable(Invention.Brick))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Furnance";
        }
    }
}
