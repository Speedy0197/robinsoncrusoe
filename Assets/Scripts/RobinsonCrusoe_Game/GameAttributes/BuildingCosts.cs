using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes
{
    public static class BuildingCosts
    {   
        public static RessourceCosts GetBuildingCosts()
        {
            if (Player.PartyHandler.PartySize == 3) return new RessourceCosts(3, 0, 0);
            if (Player.PartyHandler.PartySize == 4) return new RessourceCosts(4, 0, 0);
            return new RessourceCosts(2, 0, 0);
        }
    }
}
