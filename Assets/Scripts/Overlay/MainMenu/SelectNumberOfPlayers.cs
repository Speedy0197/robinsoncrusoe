using Assets.Scripts.Overlay.MainMenu;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNumberOfPlayers : MonoBehaviour
{
    public int numberOfPlayers = 1;
    public Button button;
    public GameObject playerSelectionScreen;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        TempoarySettings.NumberOfPlayers = numberOfPlayers;
        Destroy(playerSelectionScreen);
    }
}
