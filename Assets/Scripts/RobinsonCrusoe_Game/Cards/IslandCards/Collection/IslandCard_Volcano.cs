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
            var list = new List<RessourceType>();
            if (resFish) list.Add(RessourceType.Fish);
            if (resParrot) list.Add(RessourceType.Parrot);
            if (resWood) list.Add(RessourceType.Wood);
            return list.ToArray();
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.Volcano;
        }

        public bool IsNaturalCamp()
        {
            return false;
        }

        private bool resFish = false;
        private bool resParrot = false;
        private bool resWood = false;
        public void EndOfSource(RessourceType collectRessource)
        {
            if (collectRessource == RessourceType.Fish) resFish = false;
            if (collectRessource == RessourceType.Parrot) resParrot = false;
            if (collectRessource == RessourceType.Wood) resWood = false;
        }
        public override string ToString()
        {
            return "Vulkan";
        }
    }
}
