﻿using Assets.Scripts.Overlay.MainMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAmountOfCharacters : MonoBehaviour
{
    public Text amountText;

    private int lastAmount = 0;
    // Update is called once per frame
    void Update()
    {
        if(lastAmount != TempoarySettings.NumberOfSelectedCharacters)
        {
            lastAmount = TempoarySettings.NumberOfSelectedCharacters;
            amountText.text = TempoarySettings.NumberOfSelectedCharacters.ToString() + " / " + TempoarySettings.NumberOfPlayers.ToString();
            
            //Allow scene change
            if(TempoarySettings.NumberOfSelectedCharacters == TempoarySettings.NumberOfPlayers)
            {
                var start = FindObjectOfType<StartGameSession>();
                start.canStart = true;
            }
            else
            {
                var start = FindObjectOfType<StartGameSession>();
                start.canStart = false;
            }
        }
    }
}
