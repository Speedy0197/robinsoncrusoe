using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringActions_Processing : MonoBehaviour
{
    private ExploreIsland island;
    private Character executingCharacter;
    private ActionContainer container;
    public void ProcessCollectAction(ActionContainer action)
    {
        container = action;
        island = action.ReferingObject as ExploreIsland;
        executingCharacter = action.ExecutingCharacter;

        int amountOfActionsSpend = ProcessingHelper.CalculateAmountOfActions(action.CharacterTokensSpend);
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
            GetRessources();
        }
    }

    private void CheckForCardDraw()
    {
        var card = GatheringDice_Simulation.RollCardDice();
        Debug.Log(card);
        var deck = FindObjectOfType<GatheringCard_Deck>();
        if (deck.hasQuestionMarkOnDeck || card == CardDice.Card)
        {
            deck.DrawAndShow();
        }
    }

    private void CheckForPlayerDamage()
    {
        var damage = GatheringDice_Simulation.RollDamageDice();
        Debug.Log(damage);
        if (damage == DamageDice.Damage)
        {
            CharacterActions.DamageCharacterBy(1, executingCharacter);
        }
    }

    private void CheckForSuccess()
    {
        var success = GatheringDice_Simulation.RollSuccessDice();
        Debug.Log(success);
        if (success == SuccessDice.Determination)
        {
            CharacterActions.RaiseCharacterDeterminationBy(1, executingCharacter);
        }
        else
        {
            GetRessources();
        }
    }

    private void GetRessources()
    {
        island.myCard.GatherRessources(container.CollectRessource);
    }
}
