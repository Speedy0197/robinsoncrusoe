﻿using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards;
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
    public GameObject popUp;

    public Text cardNameText;
    public RawImage cardFaceContainer;
    public Text descriptionText;
    public Button confirmButton;

    private ICard myCard;
    private Texture2D myCardTexture;

    private void Start()
    {
        confirmButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Destroy(popUp);
        myCard.ExecuteEvent();
        if(myCard is IEventCard)
        {
            var threatStack = FindObjectOfType<ThreatCardViewer>();
            threatStack.MoveOntoThreatStack(myCard, GetCardTexture());
        }
        else
        {
            var eventStack = FindObjectOfType<Eventphase>();
            eventStack.DrawAgain();
        }
    }

    public void SetCard(ICard card)
    {
        myCard = card;
        myCardTexture = GetCardTexture();
        cardFaceContainer.texture = myCardTexture;

        cardNameText.text = myCard.ToString();
        descriptionText.text = myCard.GetCardDescription();
    }

    private Texture2D GetCardTexture()
    {
        //Check all decks
        if (myCard is IEventCard)
        {
            var eventDeck = FindObjectOfType<EventCard_Deck>();
            return eventDeck.GetTextureFromID(myCard.GetMaterialNumber());
        }
        if(myCard is IBuildingCard)
        {
            var buildingDeck = FindObjectOfType<BuildingCard_Deck>();
            return buildingDeck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
        if(myCard is IGatheringCard)
        {
            var gatheringDeck = FindObjectOfType<GatheringCard_Deck>();
            return gatheringDeck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
        if(myCard is IExploringCard)
        {
            var exploringDeck = FindObjectOfType<ExploringCard_Deck>();
            return exploringDeck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
        throw new Exception("Texture not found");
    }
}
