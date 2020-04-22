﻿using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection
{
    public class ExploringCard_Carcass : ICard, IExploringCard
    {
        private int eventNumber = 0;
        public void ExecuteEvent()
        {
            if (eventNumber == 0)
            {
                ExecuteActiveThreat();
                eventNumber++;
            }
            else
            {
                ExecuteFutureThreat();
            }
        }

        private void ExecuteFutureThreat()
        {
            Player.PartyActions.DamageAllPlayers(1);
        }

        private void ExecuteActiveThreat()
        {
            FoodStorage.IncreaseFoodBy(2);
            Fur.IncreaseBy(1);
        }

        public string GetCardDescription()
        {
            return "Du/ihr bekommt 2 Nahrung und 1 Fell. \r\n Diese Karte wird in den Eventstapel gemischt.";
        }

        public int GetMaterialNumber()
        {
            return 15;
        }

        public bool HasDiscardOption()
        {
            return true;          
        }
        public override string ToString()
        {
            return "Carcass"; 
        }
    }
}
