using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Tile09 : IIslandCard
    {
        public void Explore()
        {
            throw new NotImplementedException();
        }

        public void GatherRessources()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 9;
        }

        public bool HasCamp()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Tile09;" + GetMaterialNumber();
        }
    }
}
