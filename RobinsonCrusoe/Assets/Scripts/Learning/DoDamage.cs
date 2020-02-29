﻿using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerHelper.Instance().GetCharacter().TakePointsOfDamage(1, Assets.Scripts.RobinsonCrusoe_Game.Characters.DamageType.Damage);
        }
        if (Input.GetMouseButtonDown(1))
        {
            PlayerHelper.Instance().GetCharacter().TakePointsOfDamage(-1, Assets.Scripts.RobinsonCrusoe_Game.Characters.DamageType.Heal);
        }
    }
}
