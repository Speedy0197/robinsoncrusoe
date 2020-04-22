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
    public GameObject prefab;
    public ExploreIsland island;
    public ActionContainer myAction;
    public void ProcessCollectAction(ActionContainer action)
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
            var instance = Instantiate(prefab, ui.transform);
            instance.GetComponent<popProcess_Gather>().Process(this);
        }
        if (amountOfActionsSpend == 2)
        {
            GetRessources();
            FindObjectOfType<ActionProcesser>().ProcessNextAction();
        }
    }

    public bool CheckForCardDraw()
    {
        var card = GatheringDice_Simulation.RollCardDice();
        Debug.Log(card);
        var deck = FindObjectOfType<GatheringCard_Deck>();
        if (deck.hasQuestionMarkOnDeck || card == CardDice.Card)
        {
            return true;
        }
        return false;
    }

    public bool CheckForPlayerDamage()
    {
        var damage = GatheringDice_Simulation.RollDamageDice();
        Debug.Log(damage);
        if (damage == DamageDice.Damage)
        {
            return true;
        }
        return false;
    }

    public bool CheckForSuccess()
    {
        var success = GatheringDice_Simulation.RollSuccessDice();
        if (success == SuccessDice.Determination)
        {
            return false;
        }
        return true;
    }

    public void GetRessources()
    {
        island.myCard.GatherRessources(myAction.CollectRessource);
    }

    public void EndOfSource()
    {
        island.myCard.EndOfSource(myAction.CollectRessource);
    }
}
