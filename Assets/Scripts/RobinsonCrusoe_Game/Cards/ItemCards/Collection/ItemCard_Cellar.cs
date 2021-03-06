﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Cellar : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Cellar;
        }

        public int GetMaterialNumber()
        {
            return 6;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(0,0,0);
            return costs;
        }

        public bool IsBuildable()
        {
            if (InventionStorage.IsAvailable(Invention.Shovel))
            {
                return true;
            }
            return false;
        }
        public void Research()
        {
            //Nothing, implemented elsewhere
        }
        public override string ToString()
        {
            return "Cellar";
        }
    }
}
