using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofMarker_Complete : MonoBehaviour
{ 
    public GameObject roofMarkerObject;

    public GameObject roofPosition_0;
    public GameObject roofPosition_1;
    public GameObject roofPosition_2;
    public GameObject roofPosition_3;
    public GameObject roofPosition_4;

    private bool positionOccupied_0 = false;
    private bool positionOccupied_1 = false;
    private bool positionOccupied_2 = false;
    private bool positionOccupied_3 = false;
    private bool positionOccupied_4 = false;

    private GameObject instatiatedMarker;

    // Start is called before the first frame update
    void Start()
    {
        Roof.RoofChanged += Roof_RoofChanged;
    }

    private void Roof_RoofChanged(object sender, System.EventArgs e)
    {
        int roofState = (int)sender;
        if (roofState == 0)
        {
            if (!positionOccupied_0)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(roofMarkerObject, roofPosition_0.transform);
                positionOccupied_0 = true;
            }
        }
        else if (roofState == 1)
        {
            if (!positionOccupied_1)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(roofMarkerObject, roofPosition_1.transform);
                positionOccupied_1 = true;
            }
        }
        else if (roofState == 2)
        {
            if (!positionOccupied_2)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(roofMarkerObject, roofPosition_2.transform);
                positionOccupied_2 = true;
            }
        }
        else if (roofState == 3)
        {
            if (!positionOccupied_3)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(roofMarkerObject, roofPosition_3.transform);
                positionOccupied_3 = true;
            }
        }
        else if (roofState == 4)
        {
            if (!positionOccupied_4)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(roofMarkerObject, roofPosition_4.transform);
                positionOccupied_4 = true;
            }
        }
    }

    public void CleanLastMarker()
    {
        positionOccupied_0 = false;
        positionOccupied_1 = false;
        positionOccupied_2 = false;
        positionOccupied_3 = false;
        positionOccupied_4 = false;

        Destroy(instatiatedMarker);
    }
}
