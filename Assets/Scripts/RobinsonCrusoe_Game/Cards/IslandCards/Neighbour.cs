using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbour : MonoBehaviour
{
    public GameObject[] neighbouringIslands;

    private ExploreIsland thisIsland;
    // Start is called before the first frame update
    void Start()
    {
        thisIsland = GetComponent<ExploreIsland>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var island in neighbouringIslands)
        {
            var exploreComponent = island.GetComponent<ExploreIsland>();
            if (exploreComponent.isExplored)
            {
                thisIsland.canExplore = true;
                break;
            }
        }
    }
}
