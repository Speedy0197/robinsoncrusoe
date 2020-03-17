using Assets.Scripts.Overlay.MainMenu;
using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameSession : MonoBehaviour
{
    public Button button;
    public bool canStart = false;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (canStart)
        {
            //TODO: Initialize all the other stuff

            PartyHandler.CreateParty(TempoarySettings.Party, TempoarySettings.NumberOfPlayers);

            SceneManager.LoadScene("GameScene");
        }
    }
}
