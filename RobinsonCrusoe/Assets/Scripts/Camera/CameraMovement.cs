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
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float heightMovement = Input.GetAxis("Height") * speed * Time.deltaTime;

        transform.Translate(horizontalMovement, verticalMovement, heightMovement);
    }
}
