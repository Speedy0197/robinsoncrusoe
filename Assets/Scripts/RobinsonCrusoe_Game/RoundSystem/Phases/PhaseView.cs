using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseView : MonoBehaviour
{
    public E_Phase currentPhase;

    public event EventHandler currentPhaseChanged;

    public void ChangeCurrentPhaseTo(E_Phase phase)
    {
        currentPhase = phase;
        currentPhaseChanged.Invoke(this, new EventArgs());
    }

    public void NextPhase()
    {
        if (currentPhase == E_Phase.Event) currentPhase = E_Phase.Morale;
        else if (currentPhase == E_Phase.Morale) currentPhase = E_Phase.Production;
        else if (currentPhase == E_Phase.Production) currentPhase = E_Phase.Action;
        else if (currentPhase == E_Phase.Action) currentPhase = E_Phase.Weather;
        else if (currentPhase == E_Phase.Weather) currentPhase = E_Phase.Night;
        currentPhase = E_Phase.Event;

        currentPhaseChanged.Invoke(this, new EventArgs());
    }

    public bool created = false;
    public bool testEvent = false;
    private void Update()
    {
        if (testEvent && !created)
        {
            ChangeCurrentPhaseTo(E_Phase.Event);
            testEvent = false;
            created = true;
        }
    }
}
