﻿using Assets.Scripts.Overlay.MainMenu;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.Level;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameSession : MonoBehaviour
{
    public bool canStart = false;
    public Dropdown difficulty;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TaskOnClick()
    {
        if (canStart)
        {
            PartyHandler.CreateParty(TempoarySettings.Party, TempoarySettings.NumberOfPlayers);
            new RoundSystem(new Castaways()); //TODO: add level selection

            DifficultyHandler.Value = difficulty.GetComponent<Dropdown>().value;

            //Analytics
            var param = new Dictionary<string, object>();
            int index = 0;
            foreach(var character in PartyHandler.PartySession)
            {
                param.Add(character.CharacterName, index);
                index++;
            }
            Analytics.CustomEvent("Party", param);

            SceneManager.LoadScene("GameScene");
        }
    }
}
