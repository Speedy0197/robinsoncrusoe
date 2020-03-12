using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{

    public GameObject BuildTest;
    public GameObject BuildPostion_1;

    public void moveMarker()
    {
        BuildTest.transform.position = BuildPostion_1.transform.position;
    }
}