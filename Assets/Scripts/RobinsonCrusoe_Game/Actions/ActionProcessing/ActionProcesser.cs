using Assets.Scripts.Generic.Dice;
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
            if (action.actionType == ActionType.explore)
            {
                var processor = GetComponent<ExploreActions_Processing>();
                processor.ProcessExploreAction(action);
            }
            else if(action.actionType == ActionType.build)
            {
                var processor = GetComponent<BuildingHelper_Processing>();
                processor.ProcessExploreAction(action);
            }
            else if(action.actionType == ActionType.collect)
            {
                var processor = GetComponent<GatheringActions_Processing>();
                processor.ProcessExploreAction(action);
            }
        }

        //Change to next phase
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
    }

    private List<Action_Template> GetAllActions()
    {
        List<Action_Template> importantActions = new List<Action_Template>();

        var allActions = FindObjectsOfType<Action_Template>();
        foreach(var action in allActions)
        {
            if (action.actionType == ActionType.unknown)
                continue;
            importantActions.Add(action);
        }

        return importantActions;
    }
}
