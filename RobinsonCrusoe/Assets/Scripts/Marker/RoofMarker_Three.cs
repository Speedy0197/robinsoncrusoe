using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofMarker_Three : MonoBehaviour
{
    public GameObject roofMarker;
    private GameObject instatiatedMarker;
    private bool isOccupied;

    // Start is called before the first frame update
    void Start()
    {
        Roof.RoofChanged += Roof_RoofChanged;
        isOccupied = false;
    }

    private void Roof_RoofChanged(object sender, System.EventArgs e)
    {
        int roofState = (int)sender;
        if (roofState == 3)
        {
            if (!isOccupied)
            {
                instatiatedMarker = Instantiate(roofMarker, transform);
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
