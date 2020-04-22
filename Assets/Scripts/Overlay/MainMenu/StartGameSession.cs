using Assets.Scripts.Overlay.MainMenu;
using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
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
            var param = new Dictionary<string, object>();
            foreach(var character in PartyHandler.PartySession)
            {
                param.Add(character.CharacterName, character);
            }
            Analytics.CustomEvent("Party", param);

            SceneManager.LoadScene("GameScene");
        }
    }
}
