using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFur : MonoBehaviour
{
    public Text amountOfFur;

    // Start is called before the first frame update
    void Start()
    {
        Fur.AmountOFFurChanged += Fur_AmountOFFurChanged;
    }

    private void Fur_AmountOFFurChanged(object sender, System.EventArgs e)
    {
        int amount = (int)sender;
        amountOfFur.text = amount.ToString();
    }
}
