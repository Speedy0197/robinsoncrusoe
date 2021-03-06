﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Diary : IItemCard
    {
        public Invention GetInventionType()
        {
            return Invention.Diary;
        }

        public int GetMaterialNumber()
        {
            return 8;
        }

        public RessourceCosts GetRessourceCosts()
        {
            var costs = new RessourceCosts(0,1,0);
            return costs;
        }

        public bool IsBuildable()
        {
            return true;
        }
        public void Research()
        {
            //Nothing
        }
        public override string ToString()
        {
            return "Diary";
        }
    }
}
