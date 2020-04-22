using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofAction_Processing : MonoBehaviour
{
    public GameObject prefab;
    public ActionContainer myAction;
    public void ProcessBuildAction_Roof(ActionContainer action)
    {
        myAction = action;

        int amountOfActionsSpend = ProcessingHelper.CalculateAmountOfActions(action.CharacterTokensSpend);
        HandlePotentialDiceRoll(amountOfActionsSpend);
    }

    private void HandlePotentialDiceRoll(int amountOfActionsSpend)
    {
        if (amountOfActionsSpend == 0) return;
        if (amountOfActionsSpend == 1)
        {
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            var instance = Instantiate(prefab, ui.transform);
            instance.GetComponent<popProcess_Roof>().Process(this);
        }
        if (amountOfActionsSpend == 2)
        {
            Build();
        }
    }

    public bool CheckForCardDraw()
    {
        var card = BuildingDice_Simulation.RollCardDice();
        Debug.Log(card);
        var deck = FindObjectOfType<ExploringCard_Deck>();
        if (deck.hasQuestionMarkOnDeck || card == CardDice.Card)
        {
            return true;
        }
        return false;
    }

    public bool CheckForPlayerDamage()
    {
        var damage = BuildingDice_Simulation.RollDamageDice();
        Debug.Log(damage);
        if (damage == DamageDice.Damage)
        {
            return true;
        }
        return false;
    }

    public bool CheckForSuccess()
    {
        var success = BuildingDice_Simulation.RollSuccessDice();
        if (success == SuccessDice.Determination)
        {
            return false;
        }
        return true;
    }

    public void Build()
    {
        Roof.UpgradeRoofBy(1);
    }
}
