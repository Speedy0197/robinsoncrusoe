using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tobacco_OnClick : MonoBehaviour
{
    public GameObject token_1;
    public GameObject token_2;
    private int Charges = 2;

    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            if (Charges == 0) return;

            PartyActions.RaiseDeterminationOfPartyBy(2);

            Charges--;
            if (Charges == 1) token_1.SetActive(true);
            if (Charges == 0) token_2.SetActive(true);
        }
    }
}
