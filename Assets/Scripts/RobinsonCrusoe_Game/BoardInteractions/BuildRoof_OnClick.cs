using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoof_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable &&
            Tent.Status == TentStatus.Shelter &&
            Wood.currentAmountOfWood >= BuildingCosts.GetBuildCostsWood())
        {
            var component = GetComponent<Action_BuildRoof>();
            component.ExecuteTask();
        }
    }
}
