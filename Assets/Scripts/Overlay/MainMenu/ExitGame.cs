using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TaskOnClick()
    {
        Analytics.CustomEvent("Quit");
        Application.Quit();
    }
}
