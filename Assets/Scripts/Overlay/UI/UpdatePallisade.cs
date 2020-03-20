using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePallisade : MonoBehaviour
{
    public Text value;

    // Start is called before the first frame update
    void Start()
    {
        Wall.WallStateChanged += Wall_WallStateChanged;
    }

    private void Wall_WallStateChanged(object sender, System.EventArgs e)
    {
        int amount = (int)sender;
        value.text = amount.ToString();
    }
}
