using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMarker_Four : MonoBehaviour
{
    public GameObject wallMarker;
    private GameObject instatiatedMarker;
    private bool isOccupied;

    // Start is called before the first frame update
    void Start()
    {
        Wall.WallStateChanged += Wall_WallStateChanged;
        isOccupied = false;
    }

    private void Wall_WallStateChanged(object sender, System.EventArgs e)
    {
        int wallState = (int)sender;
        if (wallState == 4)
        {
            if (!isOccupied)
            {
                instatiatedMarker = Instantiate(wallMarker, transform);
                isOccupied = true;
            }
        }
        else
        {
            Destroy(instatiatedMarker);
            isOccupied = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
