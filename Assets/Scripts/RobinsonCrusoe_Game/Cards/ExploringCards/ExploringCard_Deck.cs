using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ExploringCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploringCard_Deck : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject questionMarkToken;
    public Texture2D[] CardFaces;

    private List<ICard> exploringDeck;
    private bool hasQuestionMarkOnDeck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    void PlayCards()
    {
        exploringDeck = GenerateNewDeck();
        DeckActions.Shuffle(exploringDeck);

        //foreach (var card in exploringDeck)
        //{
        //    Debug.Log(card);
        //}
    }

    public ICard Draw()
    {
        //Used to create an infinite amount of cards during playthrough, so that not all cards have to be implemented
        if(exploringDeck.Count == 0)
        {
            PlayCards();
        }

        var card = exploringDeck[0];
        exploringDeck.RemoveAt(0);

        return card;
    }

    public Texture2D GetMaterialFromName(int id)
    {
        return CardFaces[id];
    }

    public static List<ICard> GenerateNewDeck()
    {
        List<ICard> newDeck = new List<ICard>();

        //TODO: Change the following to include mutliple cards
        newDeck.Add(new ExploringCard_Bamboo());
        newDeck.Add(new ExploringCard_Carcass());
        newDeck.Add(new ExploringCard_ColdWind());
        newDeck.Add(new ExploringCard_OldGrave());
        newDeck.Add(new ExploringCard_TheresSomethingInTheAir());
        newDeck.Add(new ExploringCard_WildDog());
        
        return newDeck;
    }

    public void SetQuestionMarkOnDeck()
    {
        if (!hasQuestionMarkOnDeck)
        {
            hasQuestionMarkOnDeck = true;
            questionMarkToken.SetActive(true);
        }
    }
}
