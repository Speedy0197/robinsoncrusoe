using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreActions_Processing : MonoBehaviour
{
    public GameObject progressViewer;

    public ExploreIsland island;

    public ActionContainer myAction { get; private set; }
    public void ProcessExploreAction(ActionContainer action)
    {
        myAction = action;
        island = action.ReferingObject as ExploreIsland;

        int amountOfActionsSpend = ProcessingHelper.CalculateAmountOfActions(action.CharacterTokensSpend);
        HandlePotentialDiceRoll(amountOfActionsSpend);
    }

    private void HandlePotentialDiceRoll(int amountOfActionsSpend)
    {
        if (amountOfActionsSpend == 0) return;
        if (amountOfActionsSpend == 1)
        {
            var ui = FindObjectOfType<GetUIBase>().GetUI();
            var instance = Instantiate(progressViewer, ui.transform);
            instance.GetComponent<popProcess_Explore>().Process(this);
        }
        if (amountOfActionsSpend == 2)
        {
            island.Explore();
        }
    }

    public bool CheckForCardDraw()
    {
        var card = ExplorationDice_Simulation.RollCardDice();
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
        var damage = ExplorationDice_Simulation.RollDamageDice();
        Debug.Log(damage);
        if(damage == DamageDice.Damage)
        {
            return true;
        }
        return false;
    }

    public bool CheckForSuccess()
    {
        var success = ExplorationDice_Simulation.RollSuccessDice();
        if(success == SuccessDice.Determination)
        {
            return false;
        }
        return true;
    }
}
