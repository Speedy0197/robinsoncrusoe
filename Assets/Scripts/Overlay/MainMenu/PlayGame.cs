using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button button;
    public GameObject mainScreen;

    public GameObject playerSelectionScreen;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        var canvas = FindObjectOfType<Canvas>();
        Instantiate(playerSelectionScreen, canvas.transform);
        Destroy(mainScreen);
    }
}
