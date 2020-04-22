using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamp_OnClick : MonoBehaviour
{
    public GameObject myIsland;
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable &&
            myIsland.GetComponent<ExploreIsland>().isExplored &&
            !myIsland.GetComponent<ExploreIsland>().hasCamp)
        {
            var obj = FindObjectOfType<Action_MoveCamp>();
            obj.ExecuteTask(this);
        }
    }
}
