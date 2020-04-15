using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.BuildingCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCard_Deck : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject questionMarkToken;
    public Texture2D[] CardFaces;
    public GameObject popUp_Prefab;

    private List<ICard> buildingDeck;
    private bool hasQuestionMarkToken;

    // Start is called before the first frame update
    void Start()
    { 
        PlayCards();
    }

    void PlayCards()
    {
        buildingDeck = GenerateNewDeck();
        DeckActions.Shuffle(buildingDeck);

        //foreach (var card in buildingDeck)
        //{
        //    Debug.Log(card);
        //}
    }

    public void DrawAndShow()
    {
        CardsAvailable();
        RemoveQuestionMarkFromDeck();

        ICard card = Draw();
        OpenPopUp(card);
    }

    private void OpenPopUp(ICard card)
    {
        var ui = FindObjectOfType<GetUIBase>().GetUI();
        var instance = Instantiate(popUp_Prefab, ui.transform);
        var show = instance.GetComponent<PopUp_Card_Show>();
        show.SetCard(card);
    }


    private ICard Draw()
    {
        var card = buildingDeck[0];
        buildingDeck.RemoveAt(0);
        return card;
    }

    private void CardsAvailable()
    {
        if (buildingDeck.Count == 0)
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
        newDeck.Add(new BuildingCard_Breakdown());
        newDeck.Add(new BuildingCard_Construction());
        newDeck.Add(new BuildingCard_ConstructionIsWeak());
        newDeck.Add(new BuildingCard_Savings());
        newDeck.Add(new BuildingCard_Tired());
        newDeck.Add(new BuildingCard_WindStorm());

        return newDeck;
    }
    public void SetQuestionMarkOnDeck()
    {
        if (!hasQuestionMarkToken)
        {
            hasQuestionMarkToken = true;
            questionMarkToken.SetActive(true);
        }
    }

    public void RemoveQuestionMarkFromDeck()
    {
        hasQuestionMarkToken = false;
        questionMarkToken.SetActive(false);
    }
    public static void GlobalSetQuestionMarkOnDeck()
    {
        var deck = FindObjectOfType<BuildingCard_Deck>();
        deck.SetQuestionMarkOnDeck();
    }
}
