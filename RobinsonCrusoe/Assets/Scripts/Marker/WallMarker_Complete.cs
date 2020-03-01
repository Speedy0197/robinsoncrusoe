using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMarker_Complete : MonoBehaviour
{
    public GameObject wallMarkerObject;

    public GameObject wallPosition_0;
    public GameObject wallPosition_1;
    public GameObject wallPosition_2;
    public GameObject wallPosition_3;
    public GameObject wallPosition_4;

    private bool positionOccupied_0 = false;
    private bool positionOccupied_1 = false;
    private bool positionOccupied_2 = false;
    private bool positionOccupied_3 = false;
    private bool positionOccupied_4 = false;

    private GameObject instatiatedMarker;

    // Start is called before the first frame update
    void Start()
    {
        Wall.WallStateChanged += Wall_WallStateChanged;
    }

    private void Wall_WallStateChanged(object sender, System.EventArgs e)
    {
        int wallState = (int)sender;
        if (wallState == 0)
        {
            if (!positionOccupied_0)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(wallMarkerObject, wallPosition_0.transform);
                positionOccupied_0 = true;
            }
        }
        else if (wallState == 1)
        {
            if (!positionOccupied_1)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(wallMarkerObject, wallPosition_1.transform);
                positionOccupied_1 = true;
            }
        }
        else if (wallState == 2)
        {
            if (!positionOccupied_2)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(wallMarkerObject, wallPosition_2.transform);
                positionOccupied_2 = true;
            }
        }
        else if (wallState == 3)
        {
            if (!positionOccupied_3)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(wallMarkerObject, wallPosition_3.transform);
                positionOccupied_3 = true;
            }
        }
        else if (wallState == 4)
        {
            if (!positionOccupied_4)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(wallMarkerObject, wallPosition_4.transform);
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
