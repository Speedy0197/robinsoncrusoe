using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.HuntingCards.Collection
{
    public class BeastCard_Alligator : IBeastCard
    {
        public void Fight()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 0;
        }

        public override string ToString()
        {
            return "Alligator;" + GetMaterialNumber();
        }
    }
}
