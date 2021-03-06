﻿using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionProcesser : MonoBehaviour
{
    public GameObject prefab;
    List<ActionContainer> currentActions;
    int currentIndex;
    public void ProcessAllActions()
    {
        FindObjectOfType<ContinueButton>().SetClickableTo(false);

        currentActions = GetAllActions();
        currentIndex = 0;
        ProcessOneAction();
    }

    private void ProcessOneAction()
    {
        if (currentIndex >= currentActions.Count)
        {
            ChangePhase();
            return;
        }

        var action = currentActions[currentIndex];
        PartyActions.ExecutingCharacter = action.GetExecutingCharacter();

        if (action.ActionType == ActionType.preventDanger)
        {
            var processor = GetComponent<PreventDangerAction_Processing>();
            processor.ProcessPreventAction(action);
            ProcessNextAction();
        }

        else if (action.ActionType == ActionType.build)
        {
            var processor = GetComponent<BuildingHelper_Processing>();
            processor.ProcessBuildAction(action);
        }
        else if (action.ActionType == ActionType.upgradeTent)
        {
            var processor = GetComponent<TentAction_Processing>();
            processor.ProcessBuildAction_Tent(action);
        }
        else if (action.ActionType == ActionType.upgradeRoof)
        {
            var processor = GetComponent<RoofAction_Processing>();
            processor.ProcessBuildAction_Roof(action);
        }
        else if (action.ActionType == ActionType.upgradeWall)
        {
            var processor = GetComponent<WallAction_Processing>();
            processor.ProcessBuildAction_Wall(action);
        }
        else if (action.ActionType == ActionType.upgradeWeapons)
        {
            var processor = GetComponent<WeaponAction_Processing>();
            processor.ProcessBuildAction_Weapon(action);
        }

        else if (action.ActionType == ActionType.collect)
        {
            var processor = GetComponent<GatheringActions_Processing>();
            processor.ProcessCollectAction(action);
        }
        else if (action.ActionType == ActionType.explore)
        {
            var processor = GetComponent<ExploreActions_Processing>();
            processor.ProcessExploreAction(action);
        }

        else if (action.ActionType == ActionType.clean)
        {
            var processor = GetComponent<CleanAction_Processing>();
            processor.ProcessCleanAction(action);
            ProcessNextAction();
        }
        else if (action.ActionType == ActionType.rest)
        {
            var processor = GetComponent<RestAction_Processing>();
            processor.ProcessRestAction(action);
            ProcessNextAction();
        }
    }

    public void ProcessNextAction()
    {
        currentIndex++;
        ProcessOneAction();
    }

    private void ChangePhase()
    {
        //Change to next phase
        ResetCharacterActionTokens();

        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
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
            foreach (var ressourceAction in action.container)
            {
                if (ressourceAction.Value.HasStoredAction)
                    importantActions.Add(ressourceAction.Value);
            }
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

        //Tent
        var tent = FindObjectsOfType<Action_BuildTent>();
        foreach (var action in tent)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Roof
        var roof = FindObjectsOfType<Action_BuildRoof>();
        foreach (var action in roof)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Wall
        var wall = FindObjectsOfType<Action_BuildWall>();
        foreach (var action in wall)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        //Weapon
        var weapon = FindObjectsOfType<Action_BuildWeapon>();
        foreach (var action in weapon)
        {
            if (action.container.HasStoredAction)
                importantActions.Add(action.container);
        }

        return importantActions;
    }
}
