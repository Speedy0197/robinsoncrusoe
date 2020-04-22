using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards
{
    public interface IItemCard
    {
        int GetMaterialNumber();
        bool IsBuildable();
        Invention GetInventionType();
        RessourceCosts GetRessourceCosts();
        void Research();
    }
}
