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
    public GameObject questionMarkToken;
    public Texture2D[] CardFaces;

    private List<ICard> gatheringDeck;
    private bool hasQuestionMarkOnDeck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    void PlayCards()
    {
        gatheringDeck = GenerateNewDeck();
        DeckActions.Shuffle(gatheringDeck);

        //foreach (var card in gatheringDeck)
        //{
        //    Debug.Log(card);
        //}
    }

    public ICard Draw()
    {
        var card = gatheringDeck[0];
        gatheringDeck.RemoveAt(0);

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
        newDeck.Add(new GatheringCard_WeatherBreakdown());

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
