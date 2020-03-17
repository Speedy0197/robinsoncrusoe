using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards;
using Assets.Scripts.RobinsonCrusoe_Game.Cards.EventCards.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wreckage_Card : MonoBehaviour
{
    public Material cardBack;
    public Material[] cardFront;
    public GameObject instance;
    public int Position;
    public GameObject cardViewPrefab;

    private IEventCard cardClass;

    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<MeshRenderer>();

        System.Random r = new System.Random();
        int result = r.Next(1, 3);

        if(result == 1)
        {
            cardClass = new Wreckage_FoodCrate();
            renderer.material = cardFront[0];
        }
        else if(result == 2)
        {
            cardClass = new Wreckage_WreckedLifeboat();
            renderer.material = cardFront[1];
        }
        else if(result == 3)
        {
            cardClass = new Wreckage_CaptainsChest();
            renderer.material = cardFront[2];
        }

        name = cardClass.ToString();
        Move_EventCard.MoveEvent += OnMoveEvent;
    }

    private void OnMoveEvent(object sender, EventArgs e)
    {
        Move();
    }

    private void Move()
    {
        if (Position > 1)
        {
            Move_EventCard.MoveEvent -= OnMoveEvent;
            Destroy(instance);
        }
        else
        {
            var cardMover = FindObjectOfType<Move_EventCard>();
            cardMover.MoveCardOnPosition(instance, Position);
            Position++;
        }
    }
}
