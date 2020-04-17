using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gathering_Show : MonoBehaviour
{
    public Button confirm;
    public GameObject popUp;
    public GameObject firstRessource;
    public GameObject secondRessource;

    private ExploreIsland CurrentIsland;

    // Start is called before the first frame update
    void Start()
    {
        confirm.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Destroy(popUp);
    }

    public void SetIsland(ExploreIsland island)
    {
        CurrentIsland = island;
        var ressources = island.myCard.GetRessourcesOnIsland();
        for(int i = 0; i < ressources.Length; i++)
        {
            if (i == 0)
            {
                firstRessource.SetActive(true);
            }
            if(i == 1)
            {
                secondRessource.SetActive(true);
            }
            if (i < 1) break;
        }
    }
}
