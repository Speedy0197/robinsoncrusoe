using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCard_Deck : MonoBehaviour
{
    public Material[] CardFaces;
    public Material[] CardBack;
    public GameObject[] itemCardObjects;

    private List<IItemCard> itemDeck;

    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
        FillItemBoard();
    }

    void PlayCards()
    {
        itemDeck = GenerateNewDeck();
        DeckActions.Shuffle(itemDeck);

        //foreach (var card in itemDeck)
        //{
        //    Debug.Log(card);
        //}
    }

    void FillItemBoard()
    {
        foreach (var card in itemCardObjects)
        {
            var cardClass = itemDeck[0];
            itemDeck.RemoveAt(0);

            card.name = cardClass.ToString();
            int id = cardClass.GetMaterialNumber();
            var component = card.GetComponent<ItemCard>();
            component.ChangeCardClass(CardFaces[id], CardBack[id], cardClass);
        }
    }

    public static List<IItemCard> GenerateNewDeck()
    {
        List<IItemCard> newDeck = new List<IItemCard>();

        newDeck.Add(new ItemCard_Wall());
        newDeck.Add(new ItemCard_Shortcut());
        newDeck.Add(new ItemCard_Basket());
        newDeck.Add(new ItemCard_Bed());
        newDeck.Add(new ItemCard_Belt());
        newDeck.Add(new ItemCard_Bow());
        newDeck.Add(new ItemCard_Cellar());
        newDeck.Add(new ItemCard_Corral());
        newDeck.Add(new ItemCard_Diary());
        newDeck.Add(new ItemCard_Fireplace());
        newDeck.Add(new ItemCard_Furnance());
        newDeck.Add(new ItemCard_Drums());
        newDeck.Add(new ItemCard_Lantern());
        newDeck.Add(new ItemCard_Moat());
        newDeck.Add(new ItemCard_Wall());
        newDeck.Add(new ItemCard_Pit());
        newDeck.Add(new ItemCard_Raft());
        newDeck.Add(new ItemCard_Sack());
        newDeck.Add(new ItemCard_Shield());
        newDeck.Add(new ItemCard_Snare());
        newDeck.Add(new ItemCard_Spear());


        return newDeck;
    }
}
