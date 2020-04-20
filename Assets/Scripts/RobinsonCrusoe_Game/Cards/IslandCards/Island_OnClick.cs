using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Island_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            if (GetComponent<ExploreIsland>().isExplored)
            {
                var component = GetComponent<Action_Gather>();
                component.ExecuteTask();
            }
            else if(GetComponent<ExploreIsland>().canExplore)
            {
                var component = GetComponent<Action_Explore>();
                component.ExecuteTask();
            }
        }
    }
}
