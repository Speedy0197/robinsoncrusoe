using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
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

    private bool isClickable = false;

    // Start is called before the first frame update
    void Start()
    {
        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
        BtnCon.SetActive(false);
        Action_Template.ContinueButtonIsClickable += ContinueButtonIsClickable;
        Action_Template.ContinueButtonIsNotClickable += ContinueButtonIsNotClickable;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClickable)
        {
            Debug.Log("Get Shit Done");

            //Change to next phase
            var phaseView = FindObjectOfType<PhaseView>();
            phaseView.NextPhase();
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

    private void ContinueButtonIsClickable(object sender, System.EventArgs e)
    {
        BtnCon.GetComponent<RawImage>().texture = textureRed;
        isClickable = true;
    }
    private void ContinueButtonIsNotClickable(object sender, System.EventArgs e)
    {
        BtnCon.GetComponent<RawImage>().texture = texture;
        isClickable = false;
    }

}


