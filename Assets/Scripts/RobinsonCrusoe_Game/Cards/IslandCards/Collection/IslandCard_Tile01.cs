using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Tile01 : IIslandCard
    {
        public void GatherRessources(RessourceType ressource)
        {
            if(ressource == RessourceType.Parrot)
            {
                PerishableFood.IncreasePerishableFoodBy(1);
            }
        }

        public int GetMaterialNumber()
        {
            return 1;
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
            return new RessourceType[] { RessourceType.Parrot };
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
            return "Hügel";
        }
    }
}
