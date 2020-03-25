using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.HuntingCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.HuntingCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast_Deck : MonoBehaviour
{
    public Material cardBack;
    public Material[] cardFaces;

    private List<IBeastCard> beastDeck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    private void PlayCards()
    {
        beastDeck = GenerateNewDeck();
        DeckActions.Shuffle(beastDeck);

        //foreach (var card in beastDeck)
        //{
        //    Debug.Log(card);
        //}
    }

    private List<IBeastCard> GenerateNewDeck()
    {
        List<IBeastCard> newDeck = new List<IBeastCard>();

        //TODO: Change the following to include mutliple cards
        newDeck.Add(new BeastCard_Alligator());

        return newDeck;
    }

    public IBeastCard Draw()
    {
        var card = beastDeck[0];
        beastDeck.RemoveAt(0);

        return card;
    }

    public Material GetMaterialFromID(int id)
    {
        return cardFaces[id];
    }

}
