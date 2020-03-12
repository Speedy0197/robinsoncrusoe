using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour
{
    public GameObject ActionTest;

    void OnMouseDown()
    {
        ActionTest.SetActive(true);
    }

    public void  removePopup()
    {
       ActionTest.SetActive(false);
    }
}