using Assets.Scripts.RobinsonCrusoe_Game.Cards.IslandCards.Collection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIsland : MonoBehaviour
{
    public GameObject startIsland;

    // Start is called before the first frame update
    void Start()
    {
        var explore = startIsland.GetComponent<ExploreIsland>();
        explore.myCard = new IslandCard_StartingTile();
    }
}
