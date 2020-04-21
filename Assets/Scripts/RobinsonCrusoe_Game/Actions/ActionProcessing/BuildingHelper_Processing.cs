using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHelper_Processing : MonoBehaviour
{
    public GameObject popUp;

    public ItemCard item;

    public ActionContainer myAction { get; private set; }
    public void ProcessBuildAction(ActionContainer action)
    {
        myAction = action;
        item = action.ReferingObject as ItemCard;

        int amountOfActionsSpend = ProcessingHelper.CalculateAmountOfActions(action.CharacterTokensSpend);
        HandlePotentialDiceRoll(amountOfActionsSpend);
    }

    private void HandlePotentialDiceRoll(int amountOfActionsSpend)
    {
        if (amountOfActionsSpend == 0) return;
        if (amountOfActionsSpend == 1)
        {
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            var instance = Instantiate(popUp, ui.transform);
            instance.GetComponent<popProcess_Build>().Process(this);
        }
        if (amountOfActionsSpend == 2)
        {
            item.Research();
        }
    }

    public bool CheckForCardDraw()
    {
        var card = BuildingDice_Simulation.RollCardDice();
        var deck = FindObjectOfType<BuildingCard_Deck>();
        if (deck.hasQuestionMarkToken || card == CardDice.Card)
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
        Debug.Log(success);
        if (success == SuccessDice.Determination)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
