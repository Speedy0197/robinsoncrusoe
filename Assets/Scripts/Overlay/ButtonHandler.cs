using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public static event EventHandler Btn_ChangeStageClicked;

    public void Btn_ChangeStageOnClick()
    {
        Btn_ChangeStageClicked?.Invoke(this,new EventArgs());
    }

}
