using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCard_Start : MonoBehaviour
{
    public Material cardFront;
    public Material cardBack;

    public bool state = false;

    private void OnMouseDown()
    {
        state = !state;
        if (state)
        {
            GetComponent<MeshRenderer>().material = cardBack;
        }
        else
        {
            GetComponent<MeshRenderer>().material = cardFront;
        }
    }
}
