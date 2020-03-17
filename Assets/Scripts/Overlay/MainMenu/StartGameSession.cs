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

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        //TODO: Use information in TempoarySettings to create actual Party
        //Initialize all the other stuff

        PartyHandler.CreateParty(TempoarySettings.Party, TempoarySettings.NumberOfPlayers);

        SceneManager.LoadScene("GameScene");
    }
}
