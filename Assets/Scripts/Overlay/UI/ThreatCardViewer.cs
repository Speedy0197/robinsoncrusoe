using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreatCardViewer : MonoBehaviour
{
    public GameObject Card_HighThreat;
    public GameObject Card_LowThreat;
    public Texture2D Card_basicBackground;

    public GameObject threatCard_Prefab;

    private Queue<ThreatCard> threatStack = new Queue<ThreatCard>();

    private void Start()
    {
        threatStack.Enqueue(new ThreatCard(null, Card_basicBackground));

        var wreckage = FindObjectOfType<Wreckage_Card>();
        wreckage.GenerateWreckage();

        imageUpdateUI();
    }
    public void MoveOntoThreatStack(ICard card, Texture2D cardTexture)
    {
        if (card == null) cardTexture = Card_basicBackground;
        ThreatCard item = new ThreatCard(card, cardTexture);
        threatStack.Enqueue(item);
        imageUpdateUI();
    }

    public void RemoveCard(ThreatLevel threatLevel)
    {
        var array = threatStack.ToArray();
        var newStack = new Queue<ThreatCard>();

        if (threatLevel == ThreatLevel.High)
        {
            array[0] = new ThreatCard(null, Card_basicBackground);
        }
        else
        {
            array[1] = new ThreatCard(null, Card_basicBackground);
        }

        newStack.Enqueue(array[0]);
        newStack.Enqueue(array[1]);
        threatStack = newStack;

        Debug.Log("Removing");
        foreach(var item in threatStack)
        {
            Debug.Log(item);
        }

        imageUpdateUI();
    }

    private void imageUpdateUI()
    {
        if(threatStack.Count == 3)
        {
            var threatArray = threatStack.ToArray();
            Card_LowThreat.GetComponent<RawImage>().texture = threatArray[2].CardTexture;
            Card_LowThreat.GetComponent<ThreatCardHolder>().ThreatCard = threatArray[2];
            Card_LowThreat.GetComponent<ThreatCardHolder>().ThreatLevel = ThreatLevel.Low;

            Card_HighThreat.GetComponent<RawImage>().texture = threatArray[1].CardTexture;
            Card_HighThreat.GetComponent<ThreatCardHolder>().ThreatCard = threatArray[1];
            Card_HighThreat.GetComponent<ThreatCardHolder>().ThreatLevel = ThreatLevel.High;

            HandleDoomedCard();
        }
        else if(threatStack.Count == 2)
        {
            var threatArray = threatStack.ToArray();
            Card_LowThreat.GetComponent<RawImage>().texture = threatArray[1].CardTexture;
            Card_LowThreat.GetComponent<ThreatCardHolder>().ThreatCard = threatArray[1];
            Card_LowThreat.GetComponent<ThreatCardHolder>().ThreatLevel = ThreatLevel.Low;

            Card_HighThreat.GetComponent<RawImage>().texture = threatArray[0].CardTexture;
            Card_HighThreat.GetComponent<ThreatCardHolder>().ThreatCard = threatArray[0];
            Card_HighThreat.GetComponent<ThreatCardHolder>().ThreatLevel = ThreatLevel.High;
        }
    }

    private void HandleDoomedCard()
    {
        var doomedCard = threatStack.Dequeue();
        Debug.Log(doomedCard.CardClass);

        var ui = FindObjectOfType<GetUIBase>().GetUI();
        var instance = Instantiate(threatCard_Prefab, ui.transform);
        var show = instance.GetComponent<PopUp_Threat_Show>();
        show.SetCard(doomedCard.CardClass, doomedCard.CardTexture);    
    }
}

public class ThreatCard
{
    public ICard CardClass { get; private set; }
    public Texture2D CardTexture { get; private set; }
    public ThreatCard(ICard cardClass, Texture2D texture)
    {
        CardClass = cardClass;
        CardTexture = texture;
    }
}
