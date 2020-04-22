using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView_UpdateOnRoundChange : MonoBehaviour
{
    public GameObject[] views;

    private void SetToCurrentActive()
    {
        var active = PartyActions.GetActiveCharacter();

        foreach(var view in views)
        {
            if (!view.GetComponent<SmallCharacterView>().isActive) continue;

            if(view.GetComponent<SmallCharacterView>().myCharacter.CharacterName == active.CharacterName)
            {
                view.GetComponent<SmallCharacterView>().SetAsActive();
                return;
            }
        }
    }
    public static void SetToCurrentActive_Global()
    {
        FindObjectOfType<CharacterView_UpdateOnRoundChange>().SetToCurrentActive();
    }
}
