﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection
{
    public class ItemCard_Sling : IItemCard
    {
        public void Build()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 18;
        }

        public bool MaterialsAvailable()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Sling;" + GetMaterialNumber();
        }
    }
}