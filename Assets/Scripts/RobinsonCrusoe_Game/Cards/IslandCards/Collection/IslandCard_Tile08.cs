using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Tile08 : IIslandCard
    {
        public void GatherRessources(RessourceType ressource)
        {
            if(ressource == RessourceType.Wood)
            {
                Wood.IncreaseWoodBy(1);
            }
        }

        public int GetMaterialNumber()
        {
            return 8;
        }

        public int GetNumberOfAnimals()
        {
            return 1;
        }

        public int GetNumberOfDiscoveryTokens()
        {
            return 1;
        }

        public RessourceType[] GetRessourcesOnIsland()
        {
            return new RessourceType[] { RessourceType.Wood };
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.Mountain;
        }

        public bool IsNaturalCamp()
        {
            return true;
        }

        public override string ToString()
        {
            return "Nebelberg";
        }
    }
}
