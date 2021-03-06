﻿using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection
{
    public class Wreckage_FoodCrate : ICard, IEventCard
    {
        public bool CanCompleteQuest()
        {
            return true;
        }

        public void ExecuteEvent()
        {
            //Has none
        }

        public void ExecuteSuccessEvent()
        {
            //TODO: Card has an option for only one action point
            FoodStorage.IncreaseFoodBy(1);
            FoodStorage.IncreasePermantFoodBy(1);
        }

        public int GetActionCosts()
        {
            return 2;
        }

        public string GetCardDescription()
        {
            return "Nichts passiert";
        }

        public int GetMaterialNumber()
        {
            return 0;
        }

        public QuestionMark GetQuestionMark()
        {
            return QuestionMark.None;
        }

        public RessourceCosts GetRessourceCosts()
        {
            return new RessourceCosts(0, 0, 0);
        }

        public bool IsCardTypeBook()
        {
            return false;
        }
        public override string ToString()
        {
            return "Food Crate";
        }
        public bool HasDiscardOption()
        {
            return false;
        }
    }
}
