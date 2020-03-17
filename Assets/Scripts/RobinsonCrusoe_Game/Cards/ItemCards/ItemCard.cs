using Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCard : MonoBehaviour
{
    public Material cardFront;
    public Material cardBack;

    public IItemCard cardClass;
    public bool state = false;

    private void OnMouseDown()
    {
        state = !state;
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        if (state)
        {
            GetComponent<MeshRenderer>().material = cardBack;
        }
        else
        {
            GetComponent<MeshRenderer>().material = cardFront;
        }
    }

    public void ChangeCardClass(Material front, Material back, IItemCard itemCard)
    {
        cardFront = front;
        cardBack = back;
        cardClass = itemCard;

        UpdateMaterial();
    }
}
