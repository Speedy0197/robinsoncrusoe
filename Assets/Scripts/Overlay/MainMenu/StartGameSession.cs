using Assets.Scripts.Overlay.MainMenu;
using Assets.Scripts.Player;
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

            //Analytics
            string chars = string.Empty;
            foreach(var character in PartyHandler.PartySession)
            {
                chars += character.ToString() + " - ";
            }
            Analytics.CustomEvent(chars);

            SceneManager.LoadScene("GameScene");
        }
    }
}
