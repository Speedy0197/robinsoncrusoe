using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherContainer : MonoBehaviour
{
    public GameObject[] tokens;
    private int currentIndex = 0;

    public void PlaceToken(WeatherToken token)
    {
        tokens[currentIndex].SetActive(true);
        var tokenObj = tokens[currentIndex].GetComponent<WeatherToken_ChangeMaterial>();
        tokenObj.ChangeMaterialTo(token);

        currentIndex++;
    }
    public void ResetTokens()
    {
        foreach(var token in tokens)
        {
            token.SetActive(false);
        }
        currentIndex = 0;
    }


    public static void GlobalPlaceToken(WeatherToken token)
    {
        WeatherContainer container = FindObjectOfType<WeatherContainer>();
        container.PlaceToken(token);
    }

    public static void GlobalResetTokens()
    {
        WeatherContainer container = FindObjectOfType<WeatherContainer>();
        container.ResetTokens();

    }
}
