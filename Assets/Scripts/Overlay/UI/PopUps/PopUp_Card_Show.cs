﻿using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp_Card_Show : MonoBehaviour
{
    public Text cardNameText;
    public RawImage cardFaceContainer;
    public Text descriptionText;
    public Button confirmButton;

    private IEventCard myCard;
    private Texture2D myCardTexture;

    private void Start()
    {
        confirmButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        
    }

    public void SetCard(IEventCard card)
    {
        myCard = card;
        myCardTexture = GetCardTexture();
        cardFaceContainer.texture = myCardTexture;

        cardNameText.text = myCard.ToString();
        descriptionText.text = myCard.GetDescriptionText();
    }

    private Texture2D GetCardTexture()
    {
        //Check all decks

        var eventDeck = FindObjectOfType<EventCard_Deck>();
        return eventDeck.GetTextureFromID(myCard.GetMaterialNumber());
    }
}
