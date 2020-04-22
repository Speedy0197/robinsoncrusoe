using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TaskOnClick()
    {
        Analytics.CustomEvent("Started Tutorial");
        SceneManager.LoadScene("Video");
    }
}
