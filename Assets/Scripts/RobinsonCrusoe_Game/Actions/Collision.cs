using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }
}