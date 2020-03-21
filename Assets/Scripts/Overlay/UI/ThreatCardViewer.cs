using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreatCardViewer : MonoBehaviour
{
    public RawImage threatHigh;
    public RawImage threatLow;
    public Texture2D backgroundTexture;

    private ICard cardThreatHigh;
    private Texture2D cardTextureThreatHigh;

    private ICard cardThreatLow;
    private Texture2D cardTextureThreatLow;

    private void Start()
    {
        cardThreatHigh = null;
        cardThreatLow = null;
        cardTextureThreatHigh = backgroundTexture;
        cardTextureThreatLow = backgroundTexture;
    }
    public void MoveOntoThreatStack(ICard card, Texture2D cardTexture)
    {
        var doomedCard = cardThreatHigh;

        //swap low threat to high threat
        cardThreatHigh = cardThreatLow;
        if (cardThreatHigh == null) cardTextureThreatHigh = backgroundTexture;
        else cardTextureThreatHigh = cardTextureThreatLow;

        threatHigh.texture = cardTextureThreatHigh;


        //set low threat
        cardThreatLow = card;
        if(cardThreatLow == null) cardTextureThreatLow = backgroundTexture;
        else cardTextureThreatLow = cardTexture;
        threatLow.texture = cardTextureThreatLow;

        //TODO: Show PopUp with doomed card

    }
}
