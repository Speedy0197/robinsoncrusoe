using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public GameObject mainScreen;

    public GameObject playerSelectionScreen;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TaskOnClick()
    {
        var canvas = FindObjectOfType<Canvas>();
        Instantiate(playerSelectionScreen, canvas.transform);
        Destroy(mainScreen);
    }
}
