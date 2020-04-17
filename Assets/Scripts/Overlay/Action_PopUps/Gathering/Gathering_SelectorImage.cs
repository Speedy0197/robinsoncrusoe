using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gathering_SelectorImage : MonoBehaviour
{
    public Texture2D wood;
    public Texture2D food;
    public RawImage image;

    public void SetRessource(RessourceType type)
    {
        if (type == RessourceType.Wood) image.texture = wood;
        else
        {
            image.texture = food;
        }
    }
}
