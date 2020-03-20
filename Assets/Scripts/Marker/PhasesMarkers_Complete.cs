using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasesMarkers_Complete : MonoBehaviour
{
    public GameObject PhasesMarkerObject;

    public GameObject phasesPosition_1;
    public GameObject phasesPosition_2;
    public GameObject phasesPosition_3;
    public GameObject phasesPosition_4;
    public GameObject phasesPosition_5;
    public GameObject phasesPosition_6;

    private GameObject instatiatedMarker;

    // Start is called before the first frame update
    void Start()
    {
        //Phases.PhasesChanged += Phases_PhasesChanged;
    }

    private void Phases_PhasesChanged(object sender, System.EventArgs e)
    {
        int PhasesState = (int)sender;
        if (PhasesState == 1)
        {
            Destroy(instatiatedMarker);
            instatiatedMarker = Instantiate(PhasesMarkerObject, phasesPosition_1.transform);
        }

        else if (PhasesState == 2)
        {
            Destroy(instatiatedMarker);
            instatiatedMarker = Instantiate(PhasesMarkerObject, phasesPosition_2.transform);
        }
        else if (PhasesState == 3)
        {
            Destroy(instatiatedMarker);
            instatiatedMarker = Instantiate(PhasesMarkerObject, phasesPosition_3.transform);
        }
        else if (PhasesState == 4)
        {
            Destroy(instatiatedMarker);
            instatiatedMarker = Instantiate(PhasesMarkerObject, phasesPosition_4.transform);
        }
        else if (PhasesState == 5)
        {
            Destroy(instatiatedMarker);
            instatiatedMarker = Instantiate(PhasesMarkerObject, phasesPosition_5.transform);
        }
        else if (PhasesState == 6)
        {
            Destroy(instatiatedMarker);
            instatiatedMarker = Instantiate(PhasesMarkerObject, phasesPosition_6.transform);
        }

    }

}
