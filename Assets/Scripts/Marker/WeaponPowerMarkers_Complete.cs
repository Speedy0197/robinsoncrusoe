using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerMarkers_Complete : MonoBehaviour
{
    public GameObject weaponPowerMarkerObject;

    public GameObject weaponPowerPosition_0;
    public GameObject weaponPowerPosition_1;
    public GameObject weaponPowerPosition_2;
    public GameObject weaponPowerPosition_3;
    public GameObject weaponPowerPosition_4;
    public GameObject weaponPowerPosition_5;
    public GameObject weaponPowerPosition_6;
    public GameObject weaponPowerPosition_7;
    public GameObject weaponPowerPosition_8;
    public GameObject weaponPowerPosition_9;
    public GameObject weaponPowerPosition_10;

    private bool positionOccupied_0 = false;
    private bool positionOccupied_1 = false;
    private bool positionOccupied_2 = false;
    private bool positionOccupied_3 = false;
    private bool positionOccupied_4 = false;
    private bool positionOccupied_5 = false;
    private bool positionOccupied_6 = false;
    private bool positionOccupied_7 = false;
    private bool positionOccupied_8 = false;
    private bool positionOccupied_9 = false;
    private bool positionOccupied_10 = false;

    private GameObject instantiatedMarker;

    // Start is called before the first frame update
    void Start()
    {
        WeaponPower.WeaponPowerChanged += WeaponPower_WeaponPowerChanged;
    }

    private void WeaponPower_WeaponPowerChanged(object sender, System.EventArgs e)
    {
        int weaponPower = (int)sender;
        if(weaponPower == 0)
        {
            if (!positionOccupied_0)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_0.transform);
                positionOccupied_0 = true;
            }
        }
        else if (weaponPower == 1)
        {
            if (!positionOccupied_1)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_1.transform);
                positionOccupied_1 = true;
            }
        }
        else if (weaponPower == 2)
        {
            if (!positionOccupied_2)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_2.transform);
                positionOccupied_2 = true;
            }
        }
        else if (weaponPower == 3)
        {
            if (!positionOccupied_3)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_3.transform);
                positionOccupied_3 = true;
            }
        }
        else if (weaponPower == 4)
        {
            if (!positionOccupied_4)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_4.transform);
                positionOccupied_4 = true;
            }
        }
        else if (weaponPower == 5)
        {
            if (!positionOccupied_5)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_5.transform);
                positionOccupied_5 = true;
            }
        }
        else if (weaponPower == 6)
        {
            if (!positionOccupied_6)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_6.transform);
                positionOccupied_6 = true;
            }
        }
        else if (weaponPower == 7)
        {
            if (!positionOccupied_7)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_7.transform);
                positionOccupied_7 = true;
            }
        }
        else if (weaponPower == 8)
        {
            if (!positionOccupied_8)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_8.transform);
                positionOccupied_8 = true;
            }
        }
        else if (weaponPower == 9)
        {
            if (!positionOccupied_9)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_9.transform);
                positionOccupied_9 = true;
            }
        }
        else if (weaponPower == 10)
        {
            if (!positionOccupied_10)
            {
                CleanLastMarker();
                instantiatedMarker = Instantiate(weaponPowerMarkerObject, weaponPowerPosition_10.transform);
                positionOccupied_10 = true;
            }
        }
    }

    private void CleanLastMarker()
    {
        positionOccupied_0 = false;
        positionOccupied_1 = false;
        positionOccupied_2 = false;
        positionOccupied_3 = false;
        positionOccupied_4 = false;
        positionOccupied_5 = false;
        positionOccupied_6 = false;
        positionOccupied_7 = false;
        positionOccupied_8 = false;
        positionOccupied_9 = false;
        positionOccupied_10 = false;

        Destroy(instantiatedMarker);
    }
}
