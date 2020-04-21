using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWeapon_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable &&
            Tent.Status == TentStatus.Shelter &&
            Wood.currentAmountOfWood >= 1)
        {
            var component = GetComponent<Action_BuildWeapon>();
            component.ExecuteTask();
        }
    }
}
