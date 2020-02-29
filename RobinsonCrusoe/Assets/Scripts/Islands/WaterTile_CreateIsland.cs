using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile_CreateIsland : MonoBehaviour
{
    public GameObject islandObject;
    private bool isOccupied;

    private void Start()
    {
        isOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isOccupied)
        {
            Instantiate(islandObject, transform);
            isOccupied = true;
        }
    }
}
