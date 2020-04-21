using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTent_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable &&
            Tent.Status != TentStatus.Shelter)
        {
            if (Wood.currentAmountOfWood >= BuildingCosts.GetBuildCostsWood() ||
                GetComponent<Action_BuildTent>().container.HasStoredAction)
            {
                var component = GetComponent<Action_BuildTent>();
                component.ExecuteTask();
            }
        }
    }
}
