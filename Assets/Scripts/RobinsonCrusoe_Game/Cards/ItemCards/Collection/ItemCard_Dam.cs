﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Dam : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Dam;
        }

        public int GetMaterialNumber()
        {
            return 24;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(1,0,0);
            return costs;
        }

        public bool IsBuildable()
        {
            if (TerrainStorage.GetValue(TerrainType.River))
            {
                return true;
            }
            return false;
        }

        public void Research()
        {
            FoodStorage.IncreasePermantFoodBy(2);
        }

        public override string ToString()
        {
            return "Dam";
        }
    }
}
