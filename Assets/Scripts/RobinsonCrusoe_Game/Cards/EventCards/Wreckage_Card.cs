using Assets.Scripts.RobinsonCrusoe_Game.Cards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wreckage_Card : MonoBehaviour
{
    public Texture2D[] cardFront;
    private ICard cardClass;
    public void GenerateWreckage()
    {
        //System.Random r = new System.Random();
        //int result = r.Next(1, 3);

        //if (result == 1)
        //{
        //    cardClass = new Wreckage_FoodCrate();
        //}
        //else if (result == 2)
        //{
        //    cardClass = new Wreckage_WreckedLifeboat();
        //}
        //else if (result == 3)
        //{
        //    cardClass = new Wreckage_CaptainsChest();
        //}
        cardClass = new Wreckage_FoodCrate();

        var texture = cardFront[cardClass.GetMaterialNumber()];
        FindObjectOfType<ThreatCardViewer>().MoveOntoThreatStack(cardClass, texture);
    }
}
