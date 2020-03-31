using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Fireplace : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Fireplace;
        }

        public int GetMaterialNumber()
        {
            return 9;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts();
            costs.AmountOfWood = 0;
            costs.AmountOfLeather = 0;
            return costs;
        }

        public bool IsBuildable()
        {
            if (InventionStorage.IsAvailable(Invention.Fire))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Fireplace";
        }
    }
}
