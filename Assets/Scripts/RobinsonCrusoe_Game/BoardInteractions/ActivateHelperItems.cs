using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHelperItems : MonoBehaviour
{
    public GameObject biscuit;
    public GameObject rum;
    public GameObject tobacco;
    public GameObject bottle;

    // Start is called before the first frame update
    void Start()
    {
        if(DifficultyHandler.Value == 0)
        {
            biscuit.SetActive(true);
            rum.SetActive(true);
            tobacco.SetActive(true);
            bottle.SetActive(true);
        }   
        else if (DifficultyHandler.Value == 1)
        {
            biscuit.SetActive(true);
            rum.SetActive(true);
            tobacco.SetActive(true);
        }
        else if (DifficultyHandler.Value == 2)
        {
            biscuit.SetActive(true);
            rum.SetActive(true);
        }
        else if (DifficultyHandler.Value == 3)
        {
            biscuit.SetActive(true);
        }
        else if (DifficultyHandler.Value == 4)
        {
            //NO HELP AT ALL
        }
    }
}
