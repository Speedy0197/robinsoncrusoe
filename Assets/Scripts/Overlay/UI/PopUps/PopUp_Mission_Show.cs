﻿using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class PopUp_Mission_Show : MonoBehaviour
{
    public Text round;
    public Text wood;
    public Text fire;

    public GameObject roundGoal;
    public GameObject woodGoal;
    public GameObject fireGoal;

    public Button closeBtn;
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();

        closeBtn.onClick.AddListener(TaskOnClick);
    }

    public void UpdateText()
    {
        round.text = RoundSystem.instance.currentRound.ToString();
        if (RoundSystem.instance.currentRound >= 10) roundGoal.SetActive(true);

        int value = PopUp_Mission_StackOfWood.GetTotalValue();
        wood.text = value.ToString();
        Debug.Log(value);
        if (value >= 15) woodGoal.SetActive(true);

        if (InventionStorage.IsAvailable(Invention.Fire))
        {
            fire.text = "1";
            fireGoal.SetActive(true);
        }
    }

    private void TaskOnClick()
    {
        Destroy(popup);

        if (!RoundSystem.instance.started)
        {
            RoundSystem.instance.StartGame();
            Analytics.CustomEvent("Game Start");
        }
    }
}
