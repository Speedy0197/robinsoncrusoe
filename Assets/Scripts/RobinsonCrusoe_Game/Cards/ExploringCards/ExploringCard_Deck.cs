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
    public GameObject popUp_Prefab;

    private List<ICard> exploringDeck;
    public bool hasQuestionMarkOnDeck { get; private set; }

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

    public void DrawAndShow(bool processHelper)
    {
        CardsAvailable();
        RemoveQuestionMarkFormDeck();

        ICard card = Draw();
        OpenPopUp(card, processHelper);
    }

    private void OpenPopUp(ICard card, bool processHelper)
    {
        //Show Card in Popup
        var ui = FindObjectOfType<GetUIBase>().GetUI();
        var instance = Instantiate(popUp_Prefab, ui.transform);
        var show = instance.GetComponent<PopUp_DeckCard_Show>();
        show.SetCard(card, processHelper);
    }

    private ICard Draw()
    {
        var card = exploringDeck[0];
        exploringDeck.RemoveAt(0);
        return card;
    }

    private void CardsAvailable()
    {
        if (exploringDeck.Count == 0)
        {
            PlayCards();
        }
    }

    public Texture2D GetMaterialFromID(int id)
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
    public void RemoveQuestionMarkFormDeck()
    {
        hasQuestionMarkOnDeck = false;
        questionMarkToken.SetActive(false);
    }
    public static void GlobalSetQuestionMarkOnDeck()
    {
        var deck = FindObjectOfType<ExploringCard_Deck>();
        deck.SetQuestionMarkOnDeck();
    }
}
