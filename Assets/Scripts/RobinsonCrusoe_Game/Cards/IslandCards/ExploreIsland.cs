using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreIsland : MonoBehaviour
{
    public Material islandBackground;
    public bool isExplored = false;
    public bool canExplore = false;
    public bool hasCamp = false;
    public IIslandCard myCard;

    private IslandCard_Deck deck;
    private MeshRenderer mesh;

    private void Start()
    {
        deck = FindObjectOfType<IslandCard_Deck>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        if (!isExplored && canExplore)
        {
            isExplored = true;

            myCard = deck.Draw();
            mesh.material = deck.GetMaterialFromID(myCard.GetMaterialNumber());
        }
    }

    public void CampHere()
    {
        var islands = FindObjectsOfType<ExploreIsland>();
        foreach(var island in islands)
        {
            if (!island.isExplored) continue;
            island.hasCamp = false;
        }
        hasCamp = true;
    }
}
