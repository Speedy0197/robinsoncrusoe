using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Skip : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    void Start()
    {
        VideoPlayer.loopPointReached += TutEnded;
    }
    void Update()
    {
        if(Input.anyKey) SkipMovie();
    }

    void SkipMovie()
    {
        SceneManager.LoadScene("MainMenu");
        Analytics.CustomEvent("Tutorial skipped");
    }

    void TutEnded(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
        Analytics.CustomEvent("Tutorial completed");
    }
}