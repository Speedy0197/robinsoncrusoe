using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUIOnStart : MonoBehaviour
{
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(true);   
    }
}
