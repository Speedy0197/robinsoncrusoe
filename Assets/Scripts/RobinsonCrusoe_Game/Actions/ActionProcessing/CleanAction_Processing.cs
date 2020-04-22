using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanAction_Processing : MonoBehaviour
{
    public void ProcessCleanAction(ActionContainer action)
    {
        var character = action.GetExecutingCharacter();
        CharacterActions.RaiseCharacterDeterminationBy(2, character);
        Moral.RaiseMoral();
    }
}
