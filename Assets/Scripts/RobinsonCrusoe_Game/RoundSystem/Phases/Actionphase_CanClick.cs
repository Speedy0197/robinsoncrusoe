using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionphase_CanClick : MonoBehaviour
{
    public bool IsClickable = false;
    private PhaseView myview;
    private GetUIBase ui;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        myview = FindObjectOfType<PhaseView>();
        ui = FindObjectOfType<GetUIBase>();
        if (myview.currentPhase == E_Phase.Action &&
            !ui.IsBlocked)
        {
            IsClickable = true;
        }
        else IsClickable = false;
    }
}
