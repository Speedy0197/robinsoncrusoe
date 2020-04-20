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
}
