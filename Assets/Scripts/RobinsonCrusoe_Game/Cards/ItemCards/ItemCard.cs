using Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCard : MonoBehaviour
{
    public Material cardFront;
    public Material cardBack;

    public IItemCard cardClass;
    public bool isResearched = false;

    private void UpdateMaterial()
    {
        if (isResearched)
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
        Debug.Log(cardClass);
        cardFront = front;
        cardBack = back;
        cardClass = itemCard;

        UpdateMaterial();
    }

    public void Research()
    {
        if (!isResearched)
        {
            isResearched = true;
            UpdateMaterial();

            InventionStorage.UnlockInvention(cardClass.GetInventionType());

            //TODO: Apply card effects, do they even have effects?
        }
    }
}
