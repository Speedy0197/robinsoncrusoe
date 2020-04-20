using Assets.Scripts.Generic.Dice;
using Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreActions_Processing : MonoBehaviour
{
    private ExploreIsland island;
    private Character executingCharacter;
    public void ProcessExploreAction(Action_Template action)
    {
        var position = action.pos;
        island = position.ReferingObject as ExploreIsland;
        executingCharacter = ProcessingHelper.GetExecutingCharacter(position.GetDictionary());

        int amountOfActionsSpend = ProcessingHelper.CalculateAmountOfActions(position.GetDictionary());
        HandlePotentialDiceRoll(amountOfActionsSpend);
    }

    private void HandlePotentialDiceRoll(int amountOfActionsSpend)
    {
        if (amountOfActionsSpend == 0) return;
        if (amountOfActionsSpend == 1)
        {
            //TODO: show dice roll, for now just log it in console and process it (ignoring character abilities)
            CheckForSuccess();
            CheckForPlayerDamage();
            CheckForCardDraw();
        }
        if (amountOfActionsSpend == 2)
        {
            island.Explore();
        }
    }

    private void CheckForCardDraw()
    {
        var card = ExplorationDice_Simulation.RollCardDice();
        Debug.Log(card);
        var deck = FindObjectOfType<ExploringCard_Deck>();
        if (deck.hasQuestionMarkOnDeck || card == CardDice.Card)
        {
            deck.DrawAndShow();
        }
    }

    private void CheckForPlayerDamage()
    {
        var damage = ExplorationDice_Simulation.RollDamageDice();
        Debug.Log(damage);
        if(damage == DamageDice.Damage)
        {
            CharacterActions.DamageCharacterBy(1, executingCharacter);
        }
    }

    private void CheckForSuccess()
    {
        var success = ExplorationDice_Simulation.RollSuccessDice();
        Debug.Log(success);
        if(success == SuccessDice.Determination)
        {
            CharacterActions.RaiseCharacterDeterminationBy(1, executingCharacter);
        }
        else
        {
            island.Explore();
        }
    }
}
