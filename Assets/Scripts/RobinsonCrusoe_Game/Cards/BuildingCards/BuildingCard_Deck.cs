﻿using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCard_Deck : MonoBehaviour
{
    public GameObject cardPrefab;
    public Material[] CardFaces;

    private static event EventHandler DrawRequest;

    private List<IBuildingCard> buildingDeck;
    private IBuildingCard lastDrawnCard;
    private GameObject lastIntantiatedCard;

    // Start is called before the first frame update
    void Start()
    {
        DrawRequest += OnDrawRequest;

        PlayCards();
    }

    private void OnPutRequest(object sender, EventArgs e)
    {
        var card = sender as IBuildingCard;
        buildingDeck.Add(card);
        DeckActions.Shuffle(buildingDeck);
    }

    private void OnDrawRequest(object sender, EventArgs e)
    {
        Draw();
    }

    void PlayCards()
    {
        buildingDeck = GenerateNewDeck();
        DeckActions.Shuffle(buildingDeck);

        foreach (var card in buildingDeck)
        {
            Debug.Log(card);
        }
    }

    void Draw()
    {
        var card = buildingDeck[0];
        lastDrawnCard = card;
        buildingDeck.RemoveAt(0);

        GameObject newCard = Instantiate(cardPrefab, transform);
        newCard.name = card.ToString();
        lastIntantiatedCard = newCard;
    }

    public IBuildingCard GetDrawnEventClass()
    {
        return lastDrawnCard;
    }

    public GameObject GetInstantiatedEventClass()
    {
        return lastIntantiatedCard;
    }

    public Material GetMaterialFromName(string name)
    {
        string[] splitted = name.Split(';');
        int id = Convert.ToInt32(splitted[1]);

        return CardFaces[id];
    }

    public static List<IBuildingCard> GenerateNewDeck()
    {
        List<IBuildingCard> newDeck = new List<IBuildingCard>();

        //TODO: Change the following to include mutliple cards
        newDeck.Add(new BuildingCard_Breakdown());

        return newDeck;
    }

    public static void RequestDraw()
    {
        DrawRequest?.Invoke(null, new EventArgs());
    }
}