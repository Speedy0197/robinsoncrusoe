using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Rest : MonoBehaviour
{
    public GameObject actionMarker;
    public ActionContainer container = null;

    private GameObject popup;
    private GameObject instantiatedPopup;


    // Start is called before the first frame update
    void Start()
    {
        popup = Resources.Load("prefabs/PopUp_Rest") as GameObject;

        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
    }

    private void ActionPhaseTriggered(object sender, EventArgs e)
    {
        PhaseView view = (PhaseView)sender;
        if (view.GetCurrentPhase() == E_Phase.Action)
        {
            container = new ActionContainer(1);
            container.ActionType = ActionType.rest;
            container.ReferingObject = null;
        }
    }

    public void ExecuteTask()
    {
        CreatePopUp();

        var functions = instantiatedPopup.GetComponent<PopUp_Methods>();
        functions.SetActionContainer(container);

        AddListeners(functions);
    }

    private void AddListeners(PopUp_Methods functions)
    {
        functions.saveButton.onClick.AddListener(OnSave);
        functions.cancelButton.onClick.AddListener(OnCancel);
    }
    private void RemoveListeners(PopUp_Methods functions)
    {
        functions.saveButton.onClick.RemoveListener(OnSave);
        functions.cancelButton.onClick.RemoveListener(OnCancel);
    }

    private void OnCancel()
    {
        var functions = instantiatedPopup.GetComponent<PopUp_Methods>();
        functions.Cancel();

        RemoveListeners(functions);

        UpdateMarker();
        Destroy(instantiatedPopup);
    }

    private void OnSave()
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
