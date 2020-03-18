using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.DiscoveryTokens.Collection
{
    public class DiscoveryToken_Pots : IDiscoveryToken
    {
        public void Consume()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 0;
        }

        public override string ToString()
        {
            return "Discovery_Pots;" + GetMaterialNumber();
        }
    }
}
