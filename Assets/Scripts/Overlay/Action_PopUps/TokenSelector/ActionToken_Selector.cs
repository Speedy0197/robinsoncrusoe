using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionToken_Selector : MonoBehaviour
{
    public GameObject Token1;
    public GameObject Token2;
    public GameObject charName;
    public GameObject executingObj;

    public int AvailableTokens;
    public int SpendTokens = 0;

    public Character character;
    public void SetCharacter(Character c, int value)
    {
        character = c;
        charName.GetComponent<Text>().text = character.CharacterName;

        AvailableTokens = character.CurrentNumberOfActions;
        SpendTokens = value;

        UpdateTokens();
    }

    private void UpdateTokens()
    {
        if (character.MaxNumberOfActions >= 1)
        {
            Token1.SetActive(true);
            if (SpendTokens >= 1)
                Token1.GetComponent<TokenInteractions_FirstToken>().SetStartState(true);
        }
        if(character.MaxNumberOfActions >= 2)
        {
            Token2.SetActive(true);
            if (SpendTokens >= 2)
                Token1.GetComponent<TokenInteractions_SecondToken>().SetStartState(true);
        }
    }
}
