using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionProcesser : MonoBehaviour
{
    public void ProcessAllActions()
    {
        FindObjectOfType<ContinueButton>().SetClickableTo(false);
        popUpCounter = 0;

        var actions = GetAllActions();
        foreach(var action in actions)
        {
            if (action.ActionType == ActionType.explore)
            {
                var processor = GetComponent<ExploreActions_Processing>();
                processor.ProcessExploreAction(action);
            }
            else if(action.ActionType == ActionType.build)
            {
                var processor = GetComponent<BuildingHelper_Processing>();
                processor.ProcessBuildAction(action);
            }
            else if(action.ActionType == ActionType.collect)
            {
                var processor = GetComponent<GatheringActions_Processing>();
                processor.ProcessCollectAction(action);
            }
            else if(action.ActionType == ActionType.clean)
            {
                var processor = GetComponent<CleanAction_Processing>();
                processor.ProcessCleanAction(action);
            }
            else if (action.ActionType == ActionType.rest)
            {
                var processor = GetComponent<RestAction_Processing>();
                processor.ProcessRestAction(action);
            }
            else if (action.ActionType == ActionType.preventDanger)
            {
                var processor = GetComponent<PreventDangerAction_Processing>();
                processor.ProcessPreventAction(action);
            }
        }

        phaseChangeAllowed = true;
    }

    private void ResetCharacterActionTokens()
    {
        PartyActions.TokenReset();
    }

    private List<ActionContainer> GetAllActions()
    {
        List<ActionContainer> importantActions = new List<ActionContainer>();

        //Explore
        var explore = FindObjectsOfType<Action_Explore>();
        foreach(var action in explore)
        {
            if(action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Gather
        var gather = FindObjectsOfType<Action_Gather>();
        foreach (var action in gather)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Build
        var build = FindObjectsOfType<Action_Build>();
        foreach (var action in build)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Clean
        var clean = FindObjectsOfType<Action_Clean>();
        foreach (var action in clean)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Rest
        var rest = FindObjectsOfType<Action_Rest>();
        foreach (var action in rest)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Prevent
        var prevent = FindObjectsOfType<Action_PreventDanger>();
        foreach (var action in prevent)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        return importantActions;
    }

    private int popUpCounter = 0;
    public void IncreasePopUpCounter()
    {
        Debug.Log("Inc");
        popUpCounter++;
    }
    public void DecreasePopUpCounter()
    {
        Debug.Log("Dec");
        popUpCounter--;
    }

    private bool phaseChangeAllowed = false;
    private void Update()
    {
        if (phaseChangeAllowed && popUpCounter == 0)
        {
            Debug.Log("Change");
            phaseChangeAllowed = false;

            //Change to next phase
            ResetCharacterActionTokens();

            var phaseView = FindObjectOfType<PhaseView>();
            phaseView.NextPhase();
        }
    }
}
