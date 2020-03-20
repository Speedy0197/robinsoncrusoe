using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General_Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TODO: Initialize all the other stuff
        Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Roof.SetStartValue(0);
        Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Wall.SetStartState(0);
        Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.WeaponPower.SetStartValue(0);
        Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Fur.SetStartValue(0);
        Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Wood.SetStartValue(0);
        Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food.PerishableFood.SetStartValue(0);
        Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food.UnperishableFood.SetStartValue(0);
    }
}
