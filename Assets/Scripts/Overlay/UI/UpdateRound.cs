using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRound : MonoBehaviour
{
    public Text roundText;
    public Text weatherText;
    public Text stormText;

    // Start is called before the first frame update
    void Start()
    {
        RoundSystem.RoundChanged += RoundSystem_RoundChanged;

        try
        {
            weatherText.text = "Wetter: " + RoundSystem.instance.myLevel.GetWeatherRound().ToString();
            stormText.text = "Sturm: " + RoundSystem.instance.myLevel.GetStormRound().ToString();
        }
        catch { }
    }

    private void RoundSystem_RoundChanged(object sender, System.EventArgs e)
    {
        string roundString = (string)sender;
        roundText.text = roundString;
    }
}
