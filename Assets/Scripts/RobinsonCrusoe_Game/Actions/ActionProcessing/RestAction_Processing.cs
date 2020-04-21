using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAction_Processing : MonoBehaviour
{
    public void ProcessRestAction(ActionContainer action)
    {
        var character = action.ExecutingCharacter;
        CharacterActions.HealCharacterBy(2, character);
    }
}
