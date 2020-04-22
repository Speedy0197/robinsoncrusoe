using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buiscuit_OnClick : MonoBehaviour
{
    public GameObject token_1;
    public GameObject token_2;
    private int Charges = 2;

    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            if (Charges == 0) return;

            FoodStorage.IncreaseFoodBy(1);

            Charges--;
            if (Charges == 1) token_1.SetActive(true);
            if (Charges == 0) token_2.SetActive(true);
        }
    }
}
