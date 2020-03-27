using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRound : MonoBehaviour
{
    public Text roundText;
    // Start is called before the first frame update
    void Start()
    {
        RoundSystem.RoundChanged += RoundSystem_RoundChanged;
    }

    private void RoundSystem_RoundChanged(object sender, System.EventArgs e)
    {
        string roundString = (string)sender;
        roundText.text = roundString;
    }
}
