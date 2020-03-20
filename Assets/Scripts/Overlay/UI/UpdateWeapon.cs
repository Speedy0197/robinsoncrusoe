using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeapon : MonoBehaviour
{
    public Text value;

    // Start is called before the first frame update
    void Start()
    {
        WeaponPower.WeaponPowerChanged += WeaponPower_WeaponPowerChanged;
    }

    private void WeaponPower_WeaponPowerChanged(object sender, System.EventArgs e)
    {
        int amount = (int)sender;
        value.text = amount.ToString();
    }
}
