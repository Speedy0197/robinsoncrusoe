using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_EndGameScreen : MonoBehaviour
{
    public Text popupName;
    public Text infoText;
    public Button button;
    public bool isVictory;

    private void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    public void SetText(string text)
    {
        if (isVictory) popupName.text = "Entkommen!";
        else popupName.text = "Verloren";

        infoText.text = text;
    }

    public void TaskOnClick()
    {
        if (isVictory)
        {
            EndGame.Victory();
        }
        else
        {
            EndGame.Defeat();
        }
    }
}
