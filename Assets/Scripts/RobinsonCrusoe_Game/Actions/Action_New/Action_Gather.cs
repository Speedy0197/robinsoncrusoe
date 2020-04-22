using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Gather : MonoBehaviour
{
    public GameObject actionMarker;
    public Dictionary<RessourceType,ActionContainer> container = null;

    private GameObject popupCollect;
    private GameObject popupToken;
    private GameObject instantiatedPopup;
    private ExploreIsland island;

    // Start is called before the first frame update
    void Start()
    {
        island = GetComponent<ExploreIsland>();

        popupCollect = Resources.Load("prefabs/PopUp_Collect") as GameObject;
        popupToken = Resources.Load("prefabs/PopUp_Collect_Tokens") as GameObject;

        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
    }

    private void ActionPhaseTriggered(object sender, EventArgs e)
    {
        container = new Dictionary<RessourceType, ActionContainer>();
        PhaseView view = (PhaseView)sender;
        if (view.GetCurrentPhase() == E_Phase.Action && island.myCard != null)
        {
            foreach (var ressource in island.myCard.GetRessourcesOnIsland())
            {
                var action = new ActionContainer(2);
                action.ActionType = ActionType.collect;
                action.ReferingObject = island;
                action.CollectRessource = ressource;

                container.Add(ressource, action);
            }
            UpdateMarker();
        }
    }

    public void ExecuteTask()
    {
        RessourceSelection();
    }

    private void RessourceSelection()
    {
        //Open ressource selection
        //Then open token selection -> two potential ActionContainers, one for each ressource
        var spawn = FindObjectOfType<GetUIBase>().GetUI();
        instantiatedPopup = Instantiate(popupCollect, spawn.transform);

        var component = instantiatedPopup.GetComponent<PopUp_RessourceSelection>();

        component.SetSelection(island.myCard.GetRessourcesOnIsland());
        component.SelectedRessource += OnRessourceSelected;
    }

    private void OnRessourceSelected(object sender, EventArgs e)
    {
        var component = instantiatedPopup.GetComponent<PopUp_RessourceSelection>();
        component.SelectedRessource -= OnRessourceSelected;

        Destroy(instantiatedPopup);

        CreatePopUp();

        var functions = instantiatedPopup.GetComponent<PopUp_Methods>();
        functions.SetActionContainer(container[(RessourceType)sender]);

        AddListeners(functions);
    }

    public bool HasStoredAction()
    {
        foreach(var action in container)
        {
            if (action.Value.HasStoredAction) return true;
        }
        return false;
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
        var action = functions.SaveChanges();
        container[action.CollectRessource] = action;

        RemoveListeners(functions);

        UpdateMarker();
        Destroy(instantiatedPopup);
    }

    private void CreatePopUp()
    {
        var spawn = FindObjectOfType<GetUIBase>().GetUI();
        instantiatedPopup = Instantiate(popupToken, spawn.transform);
    }

    private bool IsClickable()
    {
        var obj = GetComponent<Actionphase_CanClick>();
        return obj.IsClickable;
    }

    private void UpdateMarker()
    {
        if (HasStoredAction())
        {
            actionMarker.SetActive(true);
        }
        else
        {
            actionMarker.SetActive(false);
        }
    }
}
