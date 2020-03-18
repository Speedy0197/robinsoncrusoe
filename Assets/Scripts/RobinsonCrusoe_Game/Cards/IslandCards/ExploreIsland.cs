using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreIsland : MonoBehaviour
{
    public Material islandBackground;
    public bool isExplored = false;

    private IslandCard_Deck deck;
    private MeshRenderer mesh;
    private IIslandCard myCard;
    private void Start()
    {
        deck = FindObjectOfType<IslandCard_Deck>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Explore");
        if (!isExplored)
        {
            isExplored = true;

            myCard = deck.Draw();
            mesh.material = deck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
    }
}
