using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralMarkers_Complete : MonoBehaviour
{
    public GameObject moralMarkerObject;

    public GameObject markerPosition_m3;
    public GameObject markerPosition_m2;
    public GameObject markerPosition_m1;
    public GameObject markerPosition_0;
    public GameObject markerPosition_p1;
    public GameObject markerPosition_p2;
    public GameObject markerPosition_p2h;

    private bool positionIsOccupied_m3 = false;
    private bool positionIsOccupied_m2 = false;
    private bool positionIsOccupied_m1 = false;
    private bool positionIsOccupied_0 = false;
    private bool positionIsOccupied_p1 = false;
    private bool positionIsOccupied_p2 = false;
    private bool positionIsOccupied_p2h = false;

    private GameObject instatiatedMarker;
    // Start is called before the first frame update
    void Start()
    {
        Moral.MoralStateChanged += Moral_MoralStateChanged;
    }

    private void Moral_MoralStateChanged(object sender, System.EventArgs e)
    {
        MoralState moralState = (MoralState)sender;
        if (moralState == MoralState.Demoralized)
        {
            if (!positionIsOccupied_m3)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(moralMarkerObject, markerPosition_m3.transform);
                positionIsOccupied_m3 = true;
            }
        }
        else if(moralState == MoralState.Worse)
        {
            if (!positionIsOccupied_m2)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(moralMarkerObject, markerPosition_m2.transform);
                positionIsOccupied_m2 = true;
            }
        }
        else if (moralState == MoralState.Bad)
        {
            if (!positionIsOccupied_m1)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(moralMarkerObject, markerPosition_m1.transform);
                positionIsOccupied_m1 = true;
            }
        }
        else if (moralState == MoralState.Neutral)
        {
            if (!positionIsOccupied_0)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(moralMarkerObject, markerPosition_0.transform);
                positionIsOccupied_0 = true;
            }
        }
        else if (moralState == MoralState.Good)
        {
            if (!positionIsOccupied_p1)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(moralMarkerObject, markerPosition_p1.transform);
                positionIsOccupied_p1 = true;
            }
        }
        else if (moralState == MoralState.Better)
        {
            if (!positionIsOccupied_p2)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(moralMarkerObject, markerPosition_p2.transform);
                positionIsOccupied_p2 = true;
            }
        }
        else if (moralState == MoralState.Best)
        {
            if (!positionIsOccupied_p2h)
            {
                CleanLastMarker();
                instatiatedMarker = Instantiate(moralMarkerObject, markerPosition_p2h.transform);
                positionIsOccupied_p2h = true;
            }
        }
    }

    private void CleanLastMarker()
    {
        positionIsOccupied_m3 = false;
        positionIsOccupied_m2 = false;
        positionIsOccupied_m1 = false;
        positionIsOccupied_0 = false;
        positionIsOccupied_p1 = false;
        positionIsOccupied_p2 = false;
        positionIsOccupied_p2h = false;

        Destroy(instatiatedMarker);
    }
}
