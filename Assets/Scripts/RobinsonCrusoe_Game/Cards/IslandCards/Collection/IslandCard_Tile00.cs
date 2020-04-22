﻿using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection
{
    public class IslandCard_Tile00 : IIslandCard
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
            return 0;
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
            var list = new List<RessourceType>();
            if (resFish) list.Add(RessourceType.Fish);
            if (resParrot) list.Add(RessourceType.Parrot);
            if (resWood) list.Add(RessourceType.Wood);
            return list.ToArray();
        }

        public TerrainType GetTerrain()
        {
            return TerrainType.Plain;
        }

        public bool IsNaturalCamp()
        {
            return false;
        }

        private bool resFish = false;
        private bool resParrot = false;
        private bool resWood = true;
        public void EndOfSource(RessourceType collectRessource)
        {
            if (collectRessource == RessourceType.Fish) resFish = false;
            if (collectRessource == RessourceType.Parrot) resParrot = false;
            if (collectRessource == RessourceType.Wood) resWood = false;
        }
        public override string ToString()
        {
            return "Ebene";
        }
    }
}
