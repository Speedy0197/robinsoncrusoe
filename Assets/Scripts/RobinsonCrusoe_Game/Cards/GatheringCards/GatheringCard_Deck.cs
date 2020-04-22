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
    public GameObject popUp_Prefab;

    private List<ICard> gatheringDeck;
    public bool hasQuestionMarkOnDeck { get; private set; }

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

    public void DrawAndShow(bool processHelper)
    {
        CardsAvailable();
        RemoveQuestionMarkFromDeck();

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
        var card = gatheringDeck[0];
        gatheringDeck.RemoveAt(0);
        return card;
    }

    private void CardsAvailable()
    {
        if (gatheringDeck.Count == 0)
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
        newDeck.Add(new GatheringCard_WeatherBreakdown());
        newDeck.Add(new GatheringCard_EndOfSource());
        newDeck.Add(new GatheringCard_EndOfSource());
        newDeck.Add(new GatheringCard_Mushrooms());
        newDeck.Add(new GatheringCard_Nestlings());
        newDeck.Add(new GatheringCard_NiceSurprise());

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

    public void RemoveQuestionMarkFromDeck()
    {
        hasQuestionMarkOnDeck = false;
        questionMarkToken.SetActive(false);
    }
    public static void GlobalSetQuestionMarkOnDeck()
    {
        var deck = FindObjectOfType<GatheringCard_Deck>();
        deck.SetQuestionMarkOnDeck();
    }
}
