using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerHandler : MonoBehaviour
{
    public GameObject CookMarker1;
    public GameObject CookMarker2;

    public GameObject ExplorerMarker1;
    public GameObject ExplorerMarker2;
    public GameObject CarpenterMarker1;
    public GameObject CarpenterMarker2;
    public GameObject SoldierMarker1;
    public GameObject SoldierMarker2;

    public GameObject DogMarker;
    public GameObject FridayMarker;

    public Vector3 CookMarker1InitPosition;
    public Vector3 CookMarker2InitPosition;
    public Vector3 FridayMarkerInitPosition;
    public Vector3 DogMarkerInitPosition;
    void Start()
    {
        CookMarker1InitPosition = CookMarker1.transform.position;
        CookMarker2InitPosition = CookMarker2.transform.position;
        FridayMarkerInitPosition = FridayMarker.transform.position;
        DogMarkerInitPosition = DogMarker.transform.position;

        foreach (var character in PartyHandler.PartySession)
        {
            Marker marker = new Marker();
            MarkerHandler2.dictionary.Add(character.CharacterName + "Marker1", marker);
            if (character.CharacterName != "Dog" && character.CharacterName != "Friday")
            {
                MarkerHandler2.dictionary.Add(character.CharacterName + "Marker2", marker);
            }
        }

        if (PartyHandler.PartySize == 1)
        {
            if (PartyHandler.PartySession[0].CharacterName == "Cook")
            {
                Destroy(SoldierMarker1);
                Destroy(SoldierMarker2);
                Destroy(ExplorerMarker1);
                Destroy(ExplorerMarker2);
                Destroy(CarpenterMarker1);
                Destroy(CarpenterMarker2);
            }
        }
    }

    public GameObject GetMarkerByName(string name, int markerNr)
    {
        if (name == "Cook" && markerNr == 1) return CookMarker1;
        if (name == "Cook" && markerNr == 2) return CookMarker2;
        if (name == "Dog" && markerNr == 1) return DogMarker;
        if (name == "Friday" && markerNr == 1) return FridayMarker;

        return null;
    }
    public Vector3 GetInitMarkerPositionByName(string name, int markerNr)
    {
        if (name == "Cook" && markerNr == 1) return CookMarker1InitPosition;
        if (name == "Cook" && markerNr == 2) return CookMarker2InitPosition;
        if (name == "Dog" && markerNr == 1) return DogMarkerInitPosition;
        if (name == "Friday" && markerNr == 1) return FridayMarkerInitPosition;
        return Vector3.zero;
    }



}