using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MarkerHandler : MonoBehaviour
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

    private Dictionary<string, Marker> dictionary = null;

    void start()
    {
        
        foreach (var character in PartyHandler.PartySession)
        {
            Marker marker = new Marker();
            dictionary.Add(character.CharacterName + "1", marker);
            if (character.CharacterName != "Dog" || character.CharacterName != "Friday")
            {
                dictionary.Add(character.CharacterName + "2", marker);
            }
        }

        
    }










}