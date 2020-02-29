﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIsland : MonoBehaviour
{
    public GameObject islandObject;
    private bool IsOccupied;

    // Start is called before the first frame update
    void Start()
    {
        IsOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!IsOccupied)
        {
            Instantiate(islandObject, transform);
            IsOccupied = true;
        }
    }
}
