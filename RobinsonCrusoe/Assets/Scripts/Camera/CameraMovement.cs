using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 40;

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxis("Mouse ScrollWheel") * speed * Time.deltaTime;
        if (transform.position.y < 10 || transform.position.y > 200) verticalMovement = 0;

        transform.Translate(0, verticalMovement, 0);
    }
}
