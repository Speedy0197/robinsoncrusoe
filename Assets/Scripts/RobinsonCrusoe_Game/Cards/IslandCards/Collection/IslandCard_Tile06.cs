using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Tile06 : IIslandCard
    {
        public void GatherRessources(RessourceType ressource)
        {
            if (ressource == RessourceType.Parrot)
            {
                PerishableFood.IncreaseBy(1);
            }
        }

        public int GetMaterialNumber()
        {
            return 6;
        }

        public int GetNumberOfAnimals()
        {
            return 1;
        }

        public int GetNumberOfDiscoveryTokens()
        {
            return 3;
        }

        public RessourceType[] GetRessourcesOnIsland()
        {
            return new RessourceType[] { RessourceType.Parrot };
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.Plain;
        }

        public bool IsNaturalCamp()
        {
            return false;
        }

        public override string ToString()
        {
            return "Feld";
        }
    }
}
