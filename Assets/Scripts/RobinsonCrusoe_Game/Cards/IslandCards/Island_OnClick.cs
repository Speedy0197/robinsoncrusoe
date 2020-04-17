using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Island_OnClick : MonoBehaviour
{
    public GameObject RessourcePopUp;
    public GameObject ExplorePopUp;
    public GameObject island;

    private void OnMouseDown()
    {
        Debug.Log("Click");
        if (GetComponent<Actionphase_CanClick>().IsClickable)
        {
            Debug.Log("Click - CanClick");
            if (GetComponent<ExploreIsland>().isExplored)
            {
                Debug.Log("Click - Explored");
                //Open Ressource and Build
                var ui = FindObjectOfType<GetUIBase>();
                var instance = Instantiate(RessourcePopUp, ui.transform);

            }
            else
            {
                //Open Explore
            }
        }
    }
}
