using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
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
            if (CheckBuildCosts() ||
                GetComponent<Action_BuildTent>().container.HasStoredAction)
            {
                var component = GetComponent<Action_BuildTent>();
                component.ExecuteTask();
            }
        }
    }

    private bool CheckBuildCosts()
    {
        var costs = BuildingCosts.GetBuildingCosts();
        bool retVal = true;

        if (Wood.currentAmountOfWood < costs.AmountOfWood) retVal = false;
        if (Fur.currentAmountOfFur < costs.AmountOfLeather) retVal = false;
        if (FoodStorage.GetTotal() < costs.AmountOfFood) retVal = false;
        return retVal;
    }
}
