using Assets.Scripts.Generic.Dice;
using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Actions.ActionProcessing;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAction_Processing : MonoBehaviour
{
    ActionContainer container;
    public void ProcessBuildAction_Weapon(ActionContainer action)
    {
        container = action;

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
            Build();
        }
    }

    private void CheckForCardDraw()
    {
        var card = BuildingDice_Simulation.RollCardDice();
        Debug.Log(card);
        var deck = FindObjectOfType<ExploringCard_Deck>();
        if (deck.hasQuestionMarkOnDeck || card == CardDice.Card)
        {
            deck.DrawAndShow();
        }
    }

    private void CheckForPlayerDamage()
    {
        var damage = BuildingDice_Simulation.RollDamageDice();
        Debug.Log(damage);
        if (damage == DamageDice.Damage)
        {
            CharacterActions.DamageCharacterBy(1, container.ExecutingCharacter);
        }
    }

    private void CheckForSuccess()
    {
        var success = BuildingDice_Simulation.RollSuccessDice();
        Debug.Log(success);
        if (success == SuccessDice.Determination)
        {
            CharacterActions.RaiseCharacterDeterminationBy(1, container.ExecutingCharacter);
        }
        else
        {
            Build();
        }
    }

    private void Build()
    {
        WeaponPower.RaiseWeaponPowerBy(1);
    }
}
