using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUIBase : MonoBehaviour
{
    public GameObject uiBase;

    public GameObject GetUI()
    {
        return uiBase;
    }

    public bool IsBlocked = false;
    private void Update()
    {
        if(transform.childCount == 0)
        {
            IsBlocked = false;
        }
        else
        {
            IsBlocked = true;
        }
    }

    public void DeactivateAllChildren()
    {
        var children = GetComponentsInChildren<Transform>();
        foreach(var child in children)
        {
            if (child == null) continue;
            child.gameObject.SetActive(false);
        }
    }
}
