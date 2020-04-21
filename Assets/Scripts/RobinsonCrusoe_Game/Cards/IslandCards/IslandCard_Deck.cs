using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandCard_Deck : MonoBehaviour
{
    public Material[] CardFaces;

    private List<IIslandCard> islandDeck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    void PlayCards()
    {
        islandDeck = GenerateNewDeck();
        DeckActions.Shuffle(islandDeck);

        //foreach (var card in islandDeck)
        //{
        //    Debug.Log(card);
        //}
    }

    public IIslandCard Draw()
    {
        var card = islandDeck[0];
        islandDeck.RemoveAt(0);

        return card;
    }

    public Material GetMaterialFromID(int id)
    {
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
        //newDeck.Add(new IslandCard_Volcano());

        return newDeck;
    }
}
