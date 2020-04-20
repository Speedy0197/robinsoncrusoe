using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Gather : MonoBehaviour
{
    public ActionContainer container = null;

    private GameObject popupCollect;
    private GameObject popupToken;
    private GameObject instantiatedPopup;


    // Start is called before the first frame update
    void Start()
    {
        popupCollect = Resources.Load("prefabs/PopUp_Collect") as GameObject;
        popupToken = Resources.Load("prefabs/PopUp_Explore") as GameObject;

        var view = FindObjectOfType<PhaseView>();
        view.currentPhaseChanged += ActionPhaseTriggered;
    }

    private void ActionPhaseTriggered(object sender, EventArgs e)
    {
        PhaseView view = (PhaseView)sender;
        if (view.GetCurrentPhase() == E_Phase.Action)
        {
            container = new ActionContainer(2);
            container.ActionType = ActionType.collect;
            container.ReferingObject = GetComponent<ExploreIsland>();
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
        component.SetSelection(((ExploreIsland)container.ReferingObject).myCard.GetRessourcesOnIsland());
        component.SelectedRessource += OnRessourceSelected;
    }

    private void OnRessourceSelected(object sender, EventArgs e)
    {
        var component = instantiatedPopup.GetComponent<PopUp_RessourceSelection>();
        component.SelectedRessource -= OnRessourceSelected;
        container.CollectRessource = (RessourceType)sender;
        Destroy(instantiatedPopup);

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

        Destroy(instantiatedPopup);
    }

    private void OnSave()
    {
        var functions = instantiatedPopup.GetComponent<PopUp_Methods>();
        container = functions.SaveChanges();

        RemoveListeners(functions);

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
}
