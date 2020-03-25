using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCard_Deck : MonoBehaviour
{
    public GameObject cardPrefab;
    public Texture2D[] CardFaces;

    private List<ICard> EventDeck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    void PlayCards()
    {
        EventDeck = GenerateNewDeck();
        DeckActions.Shuffle(EventDeck);

        //foreach(var card in EventDeck)
        //{
        //    Debug.Log(card);
        //}
    }

    public ICard Draw()
    {
        var card = EventDeck[0];
        EventDeck.RemoveAt(0);

        return card;
    }

    public Texture2D GetTextureFromID(int id)
    {
        return CardFaces[id];
    }

    public static List<ICard> GenerateNewDeck()
    {
        List<ICard> newDeck = new List<ICard>();
        
        //TODO: Change the following to include mutliple cards
        for(int i = 0; i < 12; i++)
        {
            newDeck.Add(new EventCard_WinterDepression());
        }
        return newDeck;
    }
}
