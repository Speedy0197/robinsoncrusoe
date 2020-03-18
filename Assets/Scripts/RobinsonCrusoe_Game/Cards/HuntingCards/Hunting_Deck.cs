using Assets.Scripts.RobinsonCrusoe_Game.Cards.HuntingCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting_Deck : MonoBehaviour
{
    private List<IBeastCard> huntingDeck;

    private void Start()
    {
        huntingDeck = new List<IBeastCard>();
    }

    public void GetBeastFromBeastDeck()
    {
        Beast_Deck beast_Deck = GetComponent<Beast_Deck>();
        huntingDeck.Add(beast_Deck.Draw());
    } 
}
