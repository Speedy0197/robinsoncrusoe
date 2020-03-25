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
    public Material[] CardFaces;

    private static event EventHandler DrawRequest;

    private List<IExploringCard> exploringDeck;
    private IExploringCard lastDrawnCard;
    private GameObject lastIntantiatedCard;

    // Start is called before the first frame update
    void Start()
    {
        DrawRequest += OnDrawRequest;

        PlayCards();
    }

    private void OnPutRequest(object sender, EventArgs e)
    {
        var card = sender as IExploringCard;
        exploringDeck.Add(card);
        DeckActions.Shuffle(exploringDeck);
    }

    private void OnDrawRequest(object sender, EventArgs e)
    {
        Draw();
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

    void Draw()
    {
        var card = exploringDeck[0];
        lastDrawnCard = card;
        exploringDeck.RemoveAt(0);

        GameObject newCard = Instantiate(cardPrefab, transform);
        newCard.name = card.ToString();
        lastIntantiatedCard = newCard;
    }

    public IExploringCard GetDrawnEventClass()
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

    public static List<IExploringCard> GenerateNewDeck()
    {
        List<IExploringCard> newDeck = new List<IExploringCard>();

        //TODO: Change the following to include mutliple cards
        newDeck.Add(new ExploringCard_Tiger());

        return newDeck;
    }

    public static void RequestDraw()
    {
        DrawRequest?.Invoke(null, new EventArgs());
    }
}
