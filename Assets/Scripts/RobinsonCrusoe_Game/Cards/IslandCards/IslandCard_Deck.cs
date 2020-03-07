using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandCard_Deck : MonoBehaviour
{
    public GameObject cardPrefab;
    public Material[] CardFaces;

    private static event EventHandler DrawRequest;
    private static event EventHandler PutRequest;

    private List<IIslandCard> islandDeck;
    private IIslandCard lastDrawnCard;

    // Start is called before the first frame update
    void Start()
    {
        DrawRequest += OnDrawRequest;
        PutRequest += OnPutRequest;

        PlayCards();
    }

    private void OnPutRequest(object sender, EventArgs e)
    {
        var card = sender as IIslandCard;
        islandDeck.Add(card);
        DeckActions.Shuffle(islandDeck);
    }

    private void OnDrawRequest(object sender, EventArgs e)
    {
        Draw();
    }

    void PlayCards()
    {
        islandDeck = GenerateNewDeck();
        DeckActions.Shuffle(islandDeck);

        foreach (var card in islandDeck)
        {
            Debug.Log(card);
        }
    }

    void Draw()
    {
        var card = islandDeck[0];
        lastDrawnCard = card;
        islandDeck.RemoveAt(0);

        GameObject newCard = Instantiate(cardPrefab, transform);
        newCard.name = card.ToString();
    }

    public IIslandCard GetDrawnEventClass()
    {
        return lastDrawnCard;
    }
    public Material GetMaterialFromName(string name)
    {
        string[] splitted = name.Split(';');
        int id = Convert.ToInt32(splitted[1]);

        return CardFaces[id];
    }

    public static List<IIslandCard> GenerateNewDeck()
    {
        List<IIslandCard> newDeck = new List<IIslandCard>();

        newDeck.Add(new IslandCard_Tile00());
        newDeck.Add(new IslandCard_Tile01());
        newDeck.Add(new IslandCard_Tile02());
        newDeck.Add(new IslandCard_Tile03());
        newDeck.Add(new IslandCard_Tile04());
        newDeck.Add(new IslandCard_Tile05());
        newDeck.Add(new IslandCard_Tile06());
        newDeck.Add(new IslandCard_Tile07());
        newDeck.Add(new IslandCard_Tile08());
        newDeck.Add(new IslandCard_Tile09());

        return newDeck;
    }

    public static void RequestDraw()
    {
        DrawRequest?.Invoke(null, new EventArgs());
    }
    public static void RequestPut(IIslandCard card)
    {
        PutRequest?.Invoke(card, new EventArgs());
    }
}
