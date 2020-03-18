using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
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
        StageHandler.CurrentStageChanged += StageHandler_CurrentStageChanged;
    }

    private void StageHandler_CurrentStageChanged(object sender, System.EventArgs e)
    {
        Stage stage = (Stage)sender;
        if (stage == Stage.Event) container.texture = eventPhase;
        if (stage == Stage.Morale) container.texture = moralePhase;
        if (stage == Stage.Production) container.texture = productionPhase;
        if (stage == Stage.Action) container.texture = actionPhase;
        if (stage == Stage.Weather) container.texture = weatherPhase;
        if (stage == Stage.Night) container.texture = nightPhase;
    }
}
