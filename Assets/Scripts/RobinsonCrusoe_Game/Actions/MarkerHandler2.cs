using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MarkerHandler2
{
    public static Dictionary<string, Marker> dictionary = new Dictionary<string, Marker>();

    public static void SetMarkerByName(string name, Vector3 position, ActionType actionType, float value)
    {
        MarkerHandler markerHandler = GameObject.Find("Board").GetComponent<MarkerHandler>();

        if (!dictionary[name + "Marker1"].isUsed)
        {
            if (name == "Cook")
            {

                markerHandler.GetMarkerByName(name, 1).transform.position = position;
                name += "Marker1";
                //TO-DO Error Sets both Marker in Dic
                Debug.Log(dictionary[name].actionType);
                dictionary[name].actionType = actionType;
                dictionary[name].isUsed = true;
                dictionary[name].value = value;
            }
            else if (name == "Friday")
            {
                markerHandler.GetMarkerByName(name, 1).transform.position = position;
                dictionary[name + "Marker1"].actionType = actionType;
                dictionary[name + "Marker1"].isUsed = true;
                dictionary[name + "Marker1"].value = value;
            }
            else if (name == "Dog")
            {
                markerHandler.GetMarkerByName(name, 1).transform.position = position;
                dictionary[name + "Marker1"].actionType = actionType;
                dictionary[name + "Marker1"].isUsed = true;
                dictionary[name + "Marker1"].value = value;
            }
        }
        else if (!dictionary[name + "Marker2"].isUsed)
        {
            if (name == "Cook")
            {
                markerHandler.GetMarkerByName(name, 2).transform.position = position;
                dictionary[name + "Marker2"].actionType = actionType;
                dictionary[name + "Marker2"].isUsed = true;
                dictionary[name + "Marker2"].value = value;
            }
        }
    }

    public static void RemoveMarkerByName(string name, Vector3 position)
    {
        MarkerHandler markerHandler = GameObject.Find("Board").GetComponent<MarkerHandler>();

        if (dictionary[name + "Marker1"].isUsed && markerHandler.GetMarkerByName(name, 1).transform.position == position)
        {
            markerHandler.GetMarkerByName(name, 1).transform.position = markerHandler.GetInitMarkerPositionByName(name, 1);
            dictionary[name + "Marker1"].actionType = ActionType.unknown;
            dictionary[name + "Marker1"].isUsed = false;
            dictionary[name + "Marker1"].value = 0;
        }
        else if(dictionary[name + "Marker2"].isUsed && markerHandler.GetMarkerByName(name, 2).transform.position == position)
        {
            markerHandler.GetMarkerByName(name, 2).transform.position = markerHandler.GetInitMarkerPositionByName(name, 2);
            dictionary[name + "Marker2"].actionType = ActionType.unknown;
            dictionary[name + "Marker2"].isUsed = false;
            dictionary[name + "Marker2"].value = 0;
        }
    }










}