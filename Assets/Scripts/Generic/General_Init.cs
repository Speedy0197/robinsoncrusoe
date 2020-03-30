using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Inventions_and_Terrain;
using Assets.Scripts.RobinsonCrusoe_Game.RoundSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General_Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TODO: Initialize all the other stuff
        Roof.SetStartValue(0);
        Wall.SetStartState(0);
        WeaponPower.SetStartValue(0);
        Fur.SetStartValue(0);
        Wood.SetStartValue(0);
        PerishableFood.SetStartValue(0);
        UnperishableFood.SetStartValue(0);
        Moral.SetStartValue();
        TerrainStorage.CreateStorageSpace();
    }
}
