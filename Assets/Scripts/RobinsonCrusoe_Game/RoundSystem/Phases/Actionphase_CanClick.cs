using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionphase_CanClick : MonoBehaviour
{
    public bool IsClickable = false;
    private PhaseView myview;
    // Start is called before the first frame update
    void Start()
    {
        myview = FindObjectOfType<PhaseView>();
        myview.currentPhaseChanged += OnPhaseChanged;
    }

    private void OnPhaseChanged(object sender, System.EventArgs e)
    {
        if (myview.currentPhase == E_Phase.Action)
        {
            IsClickable = true;
        }
        else
        {
            IsClickable = false;
        }
        
    }
}
