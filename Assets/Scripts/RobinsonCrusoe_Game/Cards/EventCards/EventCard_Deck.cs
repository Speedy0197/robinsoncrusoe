using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard_Deck : MonoBehaviour
{
    public GameObject cardPrefab;
    public Material[] CardFaces;

    private static event EventHandler DrawRequest;

    private List<IEventCard> EventDeck;

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
        EventDeck = GenerateNewDeck();
        DeckActions.Shuffle(EventDeck);

        foreach(var card in EventDeck)
        {
            Debug.Log(card);
        }
    }

    void Draw()
    {
        //TODO: delete old cards;
        var card = EventDeck[0];

        GameObject newCard = Instantiate(cardPrefab, transform);
        newCard.name = card.ToString();
    }

    public Material GetMaterialFromName(string name)
    {
        string[] splitted = name.Split(';');
        int id = Convert.ToInt32(splitted[1]);

        return CardFaces[id];
    }

    public static List<IEventCard> GenerateNewDeck()
    {
        List<IEventCard> newDeck = new List<IEventCard>();
        
        //TODO: Change the following to include mutliple cards
        for(int i = 0; i < 12; i++)
        {
            newDeck.Add(new EventCard_WinterDepression());
        }
        return newDeck;
    }

    public static void RequestDraw()
    {
        DrawRequest?.Invoke(null, new EventArgs());
    }
}
