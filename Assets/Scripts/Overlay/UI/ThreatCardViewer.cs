using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreatCardViewer : MonoBehaviour
{
    public RawImage threatHigh;
    public RawImage threatLow;

    private IEventCard cardThreatHigh;
    private Texture2D cardTextureThreatHigh;

    private IEventCard cardThreatLow;
    private Texture2D cardTextureThreatLow;

    private void SetHigh(IEventCard newCard, Texture2D cardTexture)
    {

    }

    public void SetLow(IEventCard newCard, Texture2D cardTexture)
    {

    }
}
