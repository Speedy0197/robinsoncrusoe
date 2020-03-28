using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Tile07 : IIslandCard
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
            return 7;
        }

        public int GetNumberOfAnimals()
        {
            return 1;
        }

        public int GetNumberOfDiscoveryTokens()
        {
            return 2;
        }

        public RessourceType[] GetRessourcesOnIsland()
        {
            return new RessourceType[] { RessourceType.Wood }; 
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.Hill;
        }

        public bool IsNaturalCamp()
        {
            return false;
        }
        public override string ToString()
        {
            return "Laubwald";
        }
    }
}
