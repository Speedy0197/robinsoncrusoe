using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards
{
    public interface ICard
    {
        int GetMaterialNumber();
        void ExecuteEvent();
        string GetCardDescription();
    }
}
