using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionphase_CanClick : MonoBehaviour
{
    public bool IsClickable = false;

    // Start is called before the first frame update
    void Start()
    {
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.currentPhaseChanged += OnPhaseChanged;
    }

    private void OnPhaseChanged(object sender, System.EventArgs e)
    {
        if (sender is E_Phase)
        {
            E_Phase currentPhase = (E_Phase)sender;
            if (currentPhase == E_Phase.Action)
            {
                IsClickable = true;
            }
            else
            {
                IsClickable = false;
            }
        }
    }
}
