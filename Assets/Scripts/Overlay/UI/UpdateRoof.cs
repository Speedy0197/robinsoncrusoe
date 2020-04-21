using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRoof : MonoBehaviour
{
    public Text value;

    // Start is called before the first frame update
    void Start()
    {
        Roof.RoofChanged += Roof_RoofChanged;
    }

    private void Roof_RoofChanged(object sender, System.EventArgs e)
    {
        int amount = (int)sender;
        value.text = amount.ToString();
    }
}
