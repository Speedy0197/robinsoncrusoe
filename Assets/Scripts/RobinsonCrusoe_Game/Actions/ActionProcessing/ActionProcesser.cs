using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionProcesser : MonoBehaviour
{
    public void ProcessAllActions()
    {
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
                processor.ProcessExploreAction(action);
            }
            else if(action.ActionType == ActionType.collect)
            {
                var processor = GetComponent<GatheringActions_Processing>();
                processor.ProcessExploreAction(action);
            }
        }

        //Change to next phase
        /*var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
        */
        //TODO: reset: texture of sign, actionTokens of character
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

        return importantActions;
    }
}
