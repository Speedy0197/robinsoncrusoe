﻿using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_Tiger : IExploringCard, ICard
    {
        public void ExecuteEvent()
        {
            throw new NotImplementedException();
        }

        public string GetCardDescription()
        {
            throw new NotImplementedException();
        }

        public int GetMaterialNumber()
        {
            return 0;
        }
        public override string ToString()
        {
            return "Tiger";
        }
    }
}
