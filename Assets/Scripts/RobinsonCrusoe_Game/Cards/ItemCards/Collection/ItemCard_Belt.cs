using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Belt : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Belt;
        }

        public int GetMaterialNumber()
        {
            return 4;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(0,1,0);
            return costs;
        }

        public bool IsBuildable()
        {
            if (InventionStorage.IsAvailable(Invention.Knife))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Belt";
        }
    }
}
