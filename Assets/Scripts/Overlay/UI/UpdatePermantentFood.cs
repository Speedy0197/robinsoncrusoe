using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePermantentFood : MonoBehaviour
{
    public Text amountOfFood;

    // Start is called before the first frame update
    void Start()
    {
        FoodStorage.AmountOfPermanentFoodChanged += OnPermanentFoodChanged;
    }

    private void OnPermanentFoodChanged(object sender, System.EventArgs e)
    {
        int amount = (int)sender;
        amountOfFood.text = amount.ToString();
    }
}
