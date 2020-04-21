using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_OnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            var component = GetComponent<Action_Clean>();
            component.ExecuteTask();
        }
    }
}
