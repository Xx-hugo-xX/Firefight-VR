using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    private const float ANGULAR_VELOCITY_FACTOR = 2.0f;

    private float x, y;
    private void Update()
    {
        y = Input.GetAxis("Mouse X") * ANGULAR_VELOCITY_FACTOR;
        x = Input.GetAxis("Mouse Y") * ANGULAR_VELOCITY_FACTOR;

        Vector3 rotation = new Vector3(x, y * -1, 0);
        
        transform.parent.eulerAngles = transform.parent.eulerAngles - rotation;
    }
}
