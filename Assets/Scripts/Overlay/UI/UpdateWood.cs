using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWood : MonoBehaviour
{
    public Text amountOfWood;

    // Start is called before the first frame update
    void Start()
    {
        Wood.AmountOfWoodChanged += Wood_AmountOfWoodChanged;
    }

    private void Wood_AmountOfWoodChanged(object sender, System.EventArgs e)
    {
        int amount = (int)sender;
        amountOfWood.text = amount.ToString();
    }
}
