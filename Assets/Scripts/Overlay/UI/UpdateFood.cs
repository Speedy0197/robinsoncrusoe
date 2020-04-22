using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFood : MonoBehaviour
{
    public Text numberOfFood;

    // Start is called before the first frame update
    void Start()
    {
        FoodStorage.AmountOfFoodChanged += OnFoodChanged;
    }

    private void OnFoodChanged(object sender, System.EventArgs e)
    {
        int amount = (int)sender;
        numberOfFood.text = amount.ToString();
    }
}
