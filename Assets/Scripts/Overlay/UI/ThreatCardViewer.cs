using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreatCardViewer : MonoBehaviour
{
    public RawImage Card_HighThreat;
    public RawImage Card_LowThreat;
    public Texture2D Card_basicBackground;

    private Queue<ThreatCard> threatStack = new Queue<ThreatCard>();

    private void Start()
    {
        threatStack.Enqueue(new ThreatCard(null, Card_basicBackground));
        threatStack.Enqueue(new ThreatCard(null, Card_basicBackground));
        imageUpdateUI();

        var wreckage = FindObjectOfType<Wreckage_Card>();
        wreckage.GenerateWreckage();
    }
    public void MoveOntoThreatStack(ICard card, Texture2D cardTexture)
    {
        if (card == null) cardTexture = Card_basicBackground;
        ThreatCard item = new ThreatCard(card, cardTexture);
        threatStack.Enqueue(item);
        imageUpdateUI();
    }

    private void imageUpdateUI()
    {
        if(threatStack.Count == 3)
        {
            var threatArray = threatStack.ToArray();
            Card_LowThreat.texture = threatArray[2].CardTexture;
            Card_HighThreat.texture = threatArray[1].CardTexture;

            HandleDoomedCard();
        }
        else if(threatStack.Count == 2)
        {
            var threatArray = threatStack.ToArray();
            Card_LowThreat.texture = threatArray[1].CardTexture;
            Card_HighThreat.texture = threatArray[0].CardTexture;
        }
    }

    private void HandleDoomedCard()
    {
        var doomedCard = threatStack.Dequeue();
        if (doomedCard.CardClass == null) return;
        else
        {
            //TODO: specify event??
            doomedCard.CardClass.ExecuteEvent();
        }
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
