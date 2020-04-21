using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
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

    public GameObject campPlaceholder;
    public Material camp_Fireplace;
    public Material camp_Tent;

    private IslandCard_Deck deck;
    private MeshRenderer mesh;

    private void Start()
    {
        deck = FindObjectOfType<IslandCard_Deck>();
        mesh = GetComponent<MeshRenderer>();
    }

    public void CampHere()
    {
        var islands = FindObjectsOfType<ExploreIsland>();
        foreach(var island in islands)
        {
            if (!island.isExplored) continue;
            island.SetCamp(false);
        }
        SetCamp(true);
    }

    public void Explore()
    {
        if (!isExplored && canExplore)
        {
            isExplored = true;

            myCard = deck.Draw();
            mesh.material = deck.GetMaterialFromID(myCard.GetMaterialNumber());

            TerrainStorage.UnlockTerrain(myCard.GetTerrain());

            //Spawn Hunting Cards
            /*
            int amountOfBeasts = myCard.GetNumberOfAnimals();
            var huntingDeck = FindObjectOfType<Hunting_Deck>();
            for (int i = 0; i < amountOfBeasts; i++)
            {
                huntingDeck.GetBeastFromBeastDeck();
            }

            //Spawn Discovery Tokens
            int amountOfTokens = myCard.GetNumberOfDiscoveryTokens();
            var discoveryDeck = FindObjectOfType<DiscoveryToken_Stash>();
            for(int i = 0; i < amountOfTokens; i++)
            {
                //Spawn Tokens
            }*/
        }
    }

    public void SetCamp(bool state)
    {
        if (state)
        {
            campPlaceholder.SetActive(true);
            hasCamp = true;

            if (Tent.Status == TentStatus.Fireplace)
            {
                campPlaceholder.GetComponent<MeshRenderer>().material = camp_Fireplace;
            }
            else
            {
                campPlaceholder.GetComponent<MeshRenderer>().material = camp_Tent;
            }
        }
        else
        {
            campPlaceholder.SetActive(false);
            hasCamp = false;
        }
    }
}
