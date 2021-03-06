﻿using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePhase : MonoBehaviour
{
    public Texture2D eventPhase;
    public Texture2D moralePhase;
    public Texture2D productionPhase;
    public Texture2D actionPhase;
    public Texture2D weatherPhase;
    public Texture2D nightPhase;

    private RawImage container;
    // Start is called before the first frame update
    void Start()
    {
        container = GetComponent<RawImage>();
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.currentPhaseChanged += StageHandler_CurrentStageChanged;
    }

    private void StageHandler_CurrentStageChanged(object sender, System.EventArgs e)
    {
        var phaseView = sender as PhaseView;
        E_Phase stage = phaseView.currentPhase;
        if (stage == E_Phase.Event) container.texture = eventPhase;
        if (stage == E_Phase.Morale) container.texture = moralePhase;
        if (stage == E_Phase.Production) container.texture = productionPhase;
        if (stage == E_Phase.Action) container.texture = actionPhase;
        if (stage == E_Phase.Weather) container.texture = weatherPhase;
        if (stage == E_Phase.Night) container.texture = nightPhase;
    }
}
