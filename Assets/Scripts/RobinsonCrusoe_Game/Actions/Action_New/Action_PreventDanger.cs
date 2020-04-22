using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_PreventDanger : MonoBehaviour
{
    public GameObject actionMarker;
    public ActionContainer container = null;

    private GameObject popup;
    private GameObject instantiatedPopup;


    // Start is called before the first frame update
    void Start()
    {
        popup = Resources.Load("prefabs/PopUp_PreventDanger") as GameObject;

        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
    }

    private void ActionPhaseTriggered(object sender, EventArgs e)
    {
        PhaseView view = (PhaseView)sender;
        if (view.GetCurrentPhase() == E_Phase.Action)
        {
            container = new ActionContainer(0);
            container.ActionType = ActionType.preventDanger;

            UpdateMarker();
        }
    }

    public void ExecuteTask()
    {
        var component = GetComponent<ThreatCardHolder>();
        var card = component.ThreatCard.CardClass;
        var eventCard = card as IEventCard;
        container.ActionCosts = eventCard.GetActionCosts();
        container.ReferingObject = component;

        CreatePopUp();

        var functions = instantiatedPopup.GetComponent<PopUp_Methods>();
        functions.SetActionContainer(container);
        functions.SetMinValue(container.ActionCosts);

        AddListeners(functions);
    }

    private void AddListeners(PopUp_Methods functions)
    {
        functions.saveButton.GetComponent<PopupSave>().SaveButtonClicked += OnSave;
        functions.cancelButton.GetComponent<PopupCancel>().CancelButtonClicked += OnCancel;
    }

    private void RemoveListeners(PopUp_Methods functions)
    {
        functions.saveButton.GetComponent<PopupSave>().SaveButtonClicked -= OnSave;
        functions.cancelButton.GetComponent<PopupCancel>().CancelButtonClicked -= OnCancel;
    }

    private void OnCancel(object sender, EventArgs e)
    {
        var functions = instantiatedPopup.GetComponent<PopUp_Methods>();
        functions.Cancel();

        RemoveListeners(functions);

        UpdateMarker();
        Destroy(instantiatedPopup);
    }

    private void OnSave(object sender, EventArgs e)
    {
        var functions = instantiatedPopup.GetComponent<PopUp_Methods>();
        container = functions.SaveChanges();

        RemoveListeners(functions);

        UpdateMarker();
        Destroy(instantiatedPopup);
    }

    private void CreatePopUp()
    {
        var spawn = FindObjectOfType<GetUIBase>().GetUI();
        instantiatedPopup = Instantiate(popup, spawn.transform);

        var component = GetComponent<ThreatCardHolder>();
        var tex = component.ThreatCard.CardTexture;
        instantiatedPopup.GetComponent<PopUp_Methods>().SetCardImage(tex);
    }

    private void UpdateMarker()
    {
        if (container.HasStoredAction)
        {
            actionMarker.SetActive(true);
        }
        else
        {
            actionMarker.SetActive(false);
        }
    }
}
