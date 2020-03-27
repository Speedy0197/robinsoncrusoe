using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weatherphase : MonoBehaviour
{
    public GameObject weather_Prefab;
    private PhaseView myView;

    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponent<PhaseView>();
        myView.currentPhaseChanged += OnPhaseChange;

    }

    private void OnPhaseChange(object sender, EventArgs e)
    {
        if (myView.currentPhase == E_Phase.Weather)
        {
            Debug.Log("Entered Phase: Weather");
            //Show PopUp
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            Instantiate(weather_Prefab, ui.transform);
        }
    }
}
