﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food
{
    public class FoodStorage
    {
        private static FoodStorage instance = null;

        public static FoodStorage Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodStorage();
                return instance;
            }
            
        }

        public event EventHandler TotalAmountOfFoodChanged;

        private int amountOfPerishableFood;
        private int amountOfUnperishableFood;
        private int amountOfAllFood;
        private const int minValue = 0;
        private const int maxValue = 2000; //max value unperishable + maxValue perishable

        public FoodStorage()
        {
            PerishableFood.AmountOfPerishableFoodChanged += PerishableFood_AmountOfPerishableFoodChanged;
            UnperishableFood.AmountOfUnperishableFoodChanged += UnperishableFood_AmountOfUnperishableFoodChanged;

            amountOfAllFood = minValue;
        }

        private void UnperishableFood_AmountOfUnperishableFoodChanged(object sender, EventArgs e)
        {
            amountOfUnperishableFood = (int)sender;
            UpdateAmountOfFood();
        }

        private void PerishableFood_AmountOfPerishableFoodChanged(object sender, EventArgs e)
        {
            amountOfPerishableFood = (int)sender;
            UpdateAmountOfFood();
        }

        private void  UpdateAmountOfFood()
        {
            amountOfAllFood = amountOfPerishableFood + amountOfUnperishableFood;
            TotalAmountOfFoodChanged?.Invoke(amountOfAllFood, new EventArgs());
        }
    }
}