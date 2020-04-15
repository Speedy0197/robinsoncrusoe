using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class StartGame : MonoBehaviour, IPointerClickHandler
{
    public GameObject startButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        RoundSystem.instance.StartGame();
        Analytics.CustomEvent("Game Start");
        Destroy(startButton);
    }
}
