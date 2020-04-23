using Assets.Scripts.RobinsonCrusoe_Game.Cards.ItemCards.Collection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCard_Initializer : MonoBehaviour
{
    public GameObject[] startingCards;
    // Start is called before the first frame update
    void Start()
    {
        startingCards[0].GetComponent<ItemCard>().cardClass = new ItemCard_Shovel();
        startingCards[1].GetComponent<ItemCard>().cardClass = new ItemCard_Brick();
        startingCards[2].GetComponent<ItemCard>().cardClass = new ItemCard_Cure();
        startingCards[3].GetComponent<ItemCard>().cardClass = new ItemCard_Dam();
        startingCards[4].GetComponent<ItemCard>().cardClass = new ItemCard_Fire();
        startingCards[5].GetComponent<ItemCard>().cardClass = new ItemCard_Knife();
        startingCards[6].GetComponent<ItemCard>().cardClass = new ItemCard_Map();
        startingCards[7].GetComponent<ItemCard>().cardClass = new ItemCard_Pot();
        startingCards[8].GetComponent<ItemCard>().cardClass = new ItemCard_Rope();
        startingCards[9].GetComponent<ItemCard>().cardClass = new ItemCard_Furnance();
    }
}
