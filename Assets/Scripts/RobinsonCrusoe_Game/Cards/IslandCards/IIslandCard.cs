using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards
{
    public interface IIslandCard
    {
        RessourceType[] GetRessourcesOnIsland();
        void GatherRessources(RessourceType ressource);
        bool IsNaturalCamp();
        int GetMaterialNumber();
        int GetNumberOfDiscoveryTokens();
        TerrainType GetTerrain();
        int GetNumberOfAnimals();
        void EndOfSource(RessourceType collectRessource);
    }

    public enum RessourceType
    {
        Fish,
        Parrot,
        Wood,
    }

    public enum TerrainType
    {
        Beach,
        Plain,
        Mountain,
        River,
        Hill,
        Volcano
    }
}
