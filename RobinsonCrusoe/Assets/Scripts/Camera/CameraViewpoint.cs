using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 lookVector = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookVector);
    }
}
