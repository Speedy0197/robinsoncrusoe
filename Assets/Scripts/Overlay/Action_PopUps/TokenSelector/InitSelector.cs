using Assets.Scripts.Overlay.Action_PopUps.TokenSelector;
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSelector : MonoBehaviour
{
    public GameObject[] Selectors;

    public void Init(ActionContainer actionContainer)
    {
        foreach (var selector in Selectors)
        {
            selector.SetActive(false);
        }

        for (int i = 0; i < PartyHandler.PartySession.Length; i++)
        {
            Selectors[i].SetActive(true);
            var selector = Selectors[i].GetComponent<ActionToken_Selector>();
            var c = PartyHandler.PartySession[i];
            selector.SetCharacter(c, actionContainer.GetValue(c));
        }
    }
}
