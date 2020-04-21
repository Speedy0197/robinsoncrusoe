using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            var component = GetComponent<Action_Rest>();
            component.ExecuteTask();
        }
    }
}
