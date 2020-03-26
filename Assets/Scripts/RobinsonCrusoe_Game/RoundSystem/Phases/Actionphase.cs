using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionphase : MonoBehaviour
{
    public GameObject actionphase_Prefab;
    private PhaseView myView;

    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponent<PhaseView>();
        myView.currentPhaseChanged += OnPhaseChange;
    }

    private void OnPhaseChange(object sender, EventArgs e)
    {
        if (myView.currentPhase == E_Phase.Action)
        {
            Debug.Log("Entered Phase: Event ");
            //Show PopUp
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            Instantiate(actionphase_Prefab, ui.transform);
        }
    }
}
