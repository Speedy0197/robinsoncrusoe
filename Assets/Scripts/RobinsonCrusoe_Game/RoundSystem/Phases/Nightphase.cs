using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightphase : MonoBehaviour
{
    public GameObject night_Prefab;
    private PhaseView myView;

    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponent<PhaseView>();
        myView.currentPhaseChanged += OnPhaseChange;
    }

    private void OnPhaseChange(object sender, EventArgs e)
    {
        if (myView.currentPhase == E_Phase.Night)
        {
            Debug.Log("Entered Phase: Night");
            //Show PopUp
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            Instantiate(night_Prefab, ui.transform);
        }
    }
}
