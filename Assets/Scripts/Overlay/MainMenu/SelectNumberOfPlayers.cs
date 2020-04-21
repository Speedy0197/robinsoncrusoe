using Assets.Scripts.Overlay.MainMenu;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNumberOfPlayers : MonoBehaviour
{
    public int numberOfPlayers = 1;

    public GameObject playerSelectionScreen;
    public GameObject characterSelectionScreen;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TaskOnClick()
    {
        TempoarySettings.Reset();
        TempoarySettings.NumberOfPlayers = numberOfPlayers;
        Destroy(playerSelectionScreen);

        var canvas = FindObjectOfType<Canvas>();
        Instantiate(characterSelectionScreen, canvas.transform);
    }
}
