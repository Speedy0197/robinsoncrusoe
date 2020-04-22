using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKey) SkipMovie();
    }

    private void SkipMovie()
    {
        SceneManager.LoadScene("MainMenu");
    }
}