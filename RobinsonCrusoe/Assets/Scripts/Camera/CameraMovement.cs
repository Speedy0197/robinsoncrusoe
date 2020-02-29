using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 70;

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(0, 0, verticalMovement);
    }
}
