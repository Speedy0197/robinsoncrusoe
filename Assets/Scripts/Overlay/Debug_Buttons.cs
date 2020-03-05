using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Buttons : MonoBehaviour
{
    private bool TestPlayerDmg;
    private bool TestMoralMarkers;
    private bool TestRoofMarkers;
    private bool TestWallMarkers;
    private bool TestWeaponMarkers;

    // Start is called before the first frame update
    void Start()
    {
        TestPlayerDmg = false;
        TestMoralMarkers = false;
        TestRoofMarkers = false;
        TestWallMarkers = false;
        TestWeaponMarkers = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Left
        if (Input.GetMouseButtonDown(0))
        {
            if (TestPlayerDmg) PlayerHelper.Instance().GetCharacter().TakePointsOfDamage(1, Assets.Scripts.RobinsonCrusoe_Game.Characters.DamageType.Damage);
            if (TestMoralMarkers) Moral.RaiseMoral();
            if (TestRoofMarkers) Roof.UpgradeRoofBy(1);
            if (TestWallMarkers) Wall.UpgradeWallBy(1);
            if (TestWeaponMarkers) WeaponPower.RaiseWeaponPowerBy(1);
        }

        //Right
        if (Input.GetMouseButtonDown(1))
        {
            if (TestPlayerDmg) PlayerHelper.Instance().GetCharacter().TakePointsOfDamage(1, Assets.Scripts.RobinsonCrusoe_Game.Characters.DamageType.Heal);
            if (TestMoralMarkers) Moral.LowerMoral();
            if (TestRoofMarkers) Roof.DowngradeRoofBy(1);
            if (TestWallMarkers) Wall.DowngradeWallBy(1);
            if (TestWeaponMarkers) WeaponPower.LowerWeaponPowerBy(1);
        }
    }
}
