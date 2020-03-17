﻿using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmallCharacterView : MonoBehaviour, IPointerClickHandler
{
    public Text characterName;
    public Text healthPoints;
    public RawImage characterPortrait;

    private Character myCharacter;
    private int lastHealth;

    private void Start()
    {
        lastHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastHealth != myCharacter.CurrentHealth)
        {
            healthPoints.text = myCharacter.CurrentHealth.ToString();
            lastHealth = myCharacter.CurrentHealth;
        }
    }

    public void SetCharacter(Character character)
    {
        myCharacter = character;
        characterName.text = myCharacter.CharacterName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (myCharacter is ISideCharacter) return; //Cannot click on side character, they have no abilities
        var view = FindObjectOfType<HealthView>();
        view.SetMainCharacter(myCharacter);
    }
}
