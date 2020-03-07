using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.GatheringCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringCard_Deck : MonoBehaviour
{
    public GameObject cardPrefab;
    public Material[] CardFaces;

    private static event EventHandler DrawRequest;

    private List<IGatheringCard> gatheringDeck;
    private IGatheringCard lastDrawnCard;
    private GameObject lastInstaniatedCard;

    // Start is called before the first frame update
    void Start()
    {
        DrawRequest += OnDrawRequest;

        PlayCards();
    }

    private void OnDrawRequest(object sender, EventArgs e)
    {
        Draw();
    }

    void PlayCards()
    {
        gatheringDeck = GenerateNewDeck();
        DeckActions.Shuffle(gatheringDeck);

        foreach (var card in gatheringDeck)
        {
            Debug.Log(card);
        }
    }

    void Draw()
    {
        var card = gatheringDeck[0];
        lastDrawnCard = card;
        gatheringDeck.RemoveAt(0);

        GameObject newCard = Instantiate(cardPrefab, transform);
        newCard.name = card.ToString();
        lastInstaniatedCard = newCard;
    }

    public IGatheringCard GetDrawnEventClass()
    {
        return lastDrawnCard;
    }

    public GameObject GetInstantiatedEventClass()
    {
        return lastInstaniatedCard;
    }

    public Material GetMaterialFromName(string name)
    {
        string[] splitted = name.Split(';');
        int id = Convert.ToInt32(splitted[1]);

        return CardFaces[id];
    }

    public static List<IGatheringCard> GenerateNewDeck()
    {
        List<IGatheringCard> newDeck = new List<IGatheringCard>();

        //TODO: Change the following to include mutliple cards
        newDeck.Add(new GatheringCard_WeatherBreakdown());

        return newDeck;
    }

    public static void RequestDraw()
    {
        DrawRequest?.Invoke(null, new EventArgs());
    }
}
