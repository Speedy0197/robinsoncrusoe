using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes.Food;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCard_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            if (!GetComponent<ItemCard>().isResearched &&
                GetComponent<ItemCard>().cardClass.IsBuildable())
            {
                var component = GetComponent<Action_Build>();
                component.ExecuteTask();
            }
        }
    }

    private bool CheckBuildCosts()
    {
        var costs = GetComponent<ItemCard>().cardClass.GetRessourceCosts();
        bool retVal = true;

        if (Wood.currentAmountOfWood < costs.AmountOfWood) retVal = false;
        if (Fur.currentAmountOfFur < costs.AmountOfLeather) retVal = false;
        if (FoodStorage.GetTotal() < costs.AmountOfFood) retVal = false;
        return retVal;
    }
}
