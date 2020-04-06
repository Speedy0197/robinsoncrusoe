using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Sling : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Sling;
        }

        public int GetMaterialNumber()
        {
            return 18;
        }

        public RessourceCosts GetRessourceCosts()
        {
            //TODO: leather is actually 1, but you can choose between either wood or leather. Don't know how to implement it atm
            var costs = new RessourceCosts(1,0,0);
            return costs;
        }

        public bool IsBuildable()
        {
            return true;
        }

        public override string ToString()
        {
            return "Sling";
        }
    }
}
