using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject BtnCon;
    public Texture texture;
    public Texture textureRed;

    public static event EventHandler ActionIsNotClickable;

    private bool isClickable = false;

    // Start is called before the first frame update
    void Start()
    {
        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
        BtnCon.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClickable)
        {
            var processor = FindObjectOfType<ActionProcesser>();
            processor.ProcessAllActions();
        }
    }
    private void ActionPhaseTriggered(object sender, System.EventArgs e)
    {
        PhaseView view = (PhaseView)sender;

        if (view.GetCurrentPhase() == E_Phase.Action)
        {
            BtnCon.SetActive(true);
        }
    }

    public void SetClickableTo(bool state)
    {
        isClickable = state;
        if(isClickable)
            BtnCon.GetComponent<RawImage>().texture = textureRed;
        else
            BtnCon.GetComponent<RawImage>().texture = texture;
    }
}


