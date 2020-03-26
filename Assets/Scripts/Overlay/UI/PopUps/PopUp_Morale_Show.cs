﻿using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Morale_Show : MonoBehaviour
{
    public Button confirm;
    public Button chooseHeart;
    public GameObject chooseHeartObject;
    public Button chooseMorale;
    public GameObject chooseMoraleObject;
    public Text informationText;
    public GameObject popUp;

    private bool wantsHeal = false;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);
        chooseHeart.onClick.AddListener(ChooseHearts);
        chooseMorale.onClick.AddListener(ChooseMorale);

        ShowInfoText();
        if(Moral.GetCurrentMoralState() == MoralState.Best)
        {
            chooseHeartObject.SetActive(true);
            chooseMoraleObject.SetActive(true);
        }
    }

    private void ShowInfoText()
    {
        var character = PartyActions.GetActiveCharacter();
        string info = "Der " + character.CharacterName + " erhält diese Runde " + Moral.GetMoraleString();
        informationText.text = info;
    }

    private void ChooseMorale()
    {
        wantsHeal = false;
        var btnColor = chooseMorale.GetComponent<Image>();
        btnColor.color = new Color(0, 255, 0);

        btnColor = chooseHeart.GetComponent<Image>();
        btnColor.color = new Color(0, 0, 0);
    }

    private void ChooseHearts()
    {
        wantsHeal = true;
        var btnColor = chooseHeart.GetComponent<Image>();
        btnColor.color = new Color(0, 255, 0);

        btnColor = chooseMorale.GetComponent<Image>();
        btnColor.color = new Color(0, 0, 0);
    }

    private void TaskOnClick()
    {
        var character = PartyActions.GetActiveCharacter();
        if (wantsHeal)
        {
            CharacterActions.HealCharacterBy(1, character);
        }
        else
        {
            Debug.Log(character.CharacterName + "-" + character.CurrentHealth);
            int moralevalue = Moral.GetMoraleInt();
            Debug.Log(moralevalue);
            if (moralevalue < 0)
            {
                CharacterActions.LowerCharacterDeterminationBy(moralevalue, character);
            }
            else
            {
                CharacterActions.RaiseCharacterDeterminationBy(moralevalue, character);
            }
            Debug.Log(character.CharacterName + "-" + character.CurrentHealth);
        }
        Destroy(popUp);
    }
}