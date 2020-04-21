using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRoof_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable &&
            Tent.Status == TentStatus.Shelter)
        {
            if (Wood.currentAmountOfWood >= BuildingCosts.GetBuildCostsWood() ||
            GetComponent<Action_BuildRoof>().container.HasStoredAction)
            {
                var component = GetComponent<Action_BuildRoof>();
                component.ExecuteTask();
            }
        }
    }
}
