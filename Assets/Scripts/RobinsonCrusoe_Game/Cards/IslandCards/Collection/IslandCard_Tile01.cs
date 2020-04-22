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
                FoodStorage.IncreaseFoodBy(1);
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
            var list = new List<RessourceType>();
            if (resFish) list.Add(RessourceType.Fish);
            if (resParrot) list.Add(RessourceType.Parrot);
            if (resWood) list.Add(RessourceType.Wood);
            return list.ToArray();
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.Mountain;
        }

        public bool IsNaturalCamp()
        {
            return true;
        }

        private bool resFish = false;
        private bool resParrot = true;
        private bool resWood = false;
        public void EndOfSource(RessourceType collectRessource)
        {
            if (collectRessource == RessourceType.Fish) resFish = false;
            if (collectRessource == RessourceType.Parrot) resParrot = false;
            if (collectRessource == RessourceType.Wood) resWood = false;
        }
        public override string ToString()
        {
            return "Hügel";
        }
    }
}
