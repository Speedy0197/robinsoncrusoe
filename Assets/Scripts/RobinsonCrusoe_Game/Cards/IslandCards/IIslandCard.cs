using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards
{
    public interface IIslandCard
    {
        void GatherRessources();
        void Explore();
        bool HasCamp();
        int GetMaterialNumber();
    }
}
