using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAction_Processing : MonoBehaviour
{
    public void ProcessRestAction(ActionContainer action)
    {
        var character = action.GetExecutingCharacter();

        if (InventionStorage.IsAvailable(Invention.Bed))
        {
            var active = PartyActions.ExecutingCharacter;
            CharacterActions.RaiseCharacterDeterminationBy(1, active);
            CharacterActions.HealCharacterBy(2, active);
        }
        else
        {
            var active = PartyActions.ExecutingCharacter;
            CharacterActions.HealCharacterBy(1, active);
        }
    }
}
