using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_EventCard : MonoBehaviour
{
    public static event EventHandler MoveEvent;

    public Transform NearDanger;
    public Transform InDanger;

    public void MoveCardOnPosition(GameObject card, int pos)
    {
        //TODO: Get these vectors right, so that the cards are at the exact position
        if (pos == 0)
        {
            Vector3 vector = new Vector3(NearDanger.transform.position.x, NearDanger.transform.position.y + 20f, NearDanger.position.z);
            card.transform.position = vector;
        }
        if(pos == 1)
        {
            Vector3 vector = new Vector3(InDanger.transform.position.x, InDanger.transform.position.y + 20f, InDanger.position.z);
            card.transform.position = vector;
        }
    }

    public static void RequestMove()
    {
        MoveEvent?.Invoke(null, new EventArgs());
    }
}
