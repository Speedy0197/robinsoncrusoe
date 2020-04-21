using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class BuildingCosts
    {   
        public static int GetBuildCostsWood()
        {
            if (Player.PartyHandler.PartySize == 2) return 2;
            if (Player.PartyHandler.PartySize == 3) return 3;
            if (Player.PartyHandler.PartySize == 4) return 4;
            return 1;
        }
    }
}
