using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Tile09 : IIslandCard
    {
        public void GatherRessources(RessourceType ressource)
        {
            if(ressource == RessourceType.Fish)
            {
                PerishableFood.IncreasePerishableFoodBy(1);
            }
            else if(ressource == RessourceType.Wood)
            {
                Wood.IncreaseWoodBy(1);
            }
        }

        public int GetMaterialNumber()
        {
            return 9;
        }

        public int GetNumberOfAnimals()
        {
            return 0;
        }

        public int GetNumberOfDiscoveryTokens()
        {
            return 1;
        }

        public RessourceType[] GetRessourcesOnIsland()
        {
            return new RessourceType[] { RessourceType.Wood, RessourceType.Fish };
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.River;
        }

        public bool IsNaturalCamp()
        {
            return false;
        }

        public override string ToString()
        {
            return "Bach";
        }
    }
}
