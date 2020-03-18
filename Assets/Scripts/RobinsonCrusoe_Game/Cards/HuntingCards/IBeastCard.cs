using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.HuntingCards
{
    public interface IBeastCard
    {
        int GetMaterialNumber();
        void Fight();
    }
}
