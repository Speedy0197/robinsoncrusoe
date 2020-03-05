using Assets.Scripts.Player;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public bool btn_ChangeStageclicked = false;

    public void Btn_ChangeStageOnClick()
    {
       btn_ChangeStageclicked = true;
    }

}
