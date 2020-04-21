using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject previousScreenPrefab;

    public GameObject currentScreen;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TaskOnClick()
    {
        var canvas = FindObjectOfType<Canvas>();
        Instantiate(previousScreenPrefab, canvas.transform);
        Destroy(currentScreen);
    }
}
