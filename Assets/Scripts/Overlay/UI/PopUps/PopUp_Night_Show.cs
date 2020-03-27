﻿using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Night_Show : MonoBehaviour
{
    public Button confirm;
    public Text infoText;
    public GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);
        infoText.text = "Die Nacht senkt sich über die Insel.\r\nDie Gruppe isst " + PartyHandler.PartySize.ToString() + " Einheiten Nahrung";

        //TODO: check if enough food is available, let the players choose who starves
    }

    private void TaskOnClick()
    {
        //TODO: deal damage to starving player
        FoodStorage.Instance.ConsumeFood(PartyHandler.PartySize);

        Destroy(popUp);
        var phaseView = FindObjectOfType<PhaseView>();
        phaseView.NextPhase();
        RoundSystem.instance.increaseRound();
    }
}
