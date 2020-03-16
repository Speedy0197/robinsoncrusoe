using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject previousScreenPrefab;

    public Button button;
    public GameObject currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        var canvas = FindObjectOfType<Canvas>();
        Instantiate(previousScreenPrefab, canvas.transform);
        Destroy(currentScreen);
    }
}
