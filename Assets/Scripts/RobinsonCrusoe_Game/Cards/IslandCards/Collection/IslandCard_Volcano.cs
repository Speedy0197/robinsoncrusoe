using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Volcano : IIslandCard
    {
        public void GatherRessources(RessourceType ressource)
        {
            return;
        }

        public int GetMaterialNumber()
        {
            return 11;
        }

        public int GetNumberOfAnimals()
        {
            return 0;
        }

        public int GetNumberOfDiscoveryTokens()
        {
            return 0;
        }

        public RessourceType[] GetRessourcesOnIsland()
        {
            return null;
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.Volcano;
        }

        public bool IsNaturalCamp()
        {
            return false;
        }

        public override string ToString()
        {
            return "Vulkan";
        }
    }
}
