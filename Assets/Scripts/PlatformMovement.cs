using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float hMovSpeed = 1;
    public float vMovSpeed = 1;
    [HideInInspector] public float hMov;
    [HideInInspector] public float vMov;

    #region Bound Vars

    public float topBound = 30.8f;
    public float bottomBound = 3.3f;
    public float leftBound = 7.4f;
    public float rightBound = -7.8f;

    #endregion

    private void Start()
    {
    }

    void Update()
    {
        if (hMov >= 0.5f || hMov <= -0.5f) vMov = 0;
        else if (transform.localPosition.y > topBound && Input.GetAxisRaw("Vertical") > 0) vMov = 0;
        else if (transform.localPosition.y < bottomBound && Input.GetAxisRaw("Vertical") < 0) vMov = 0;
        else vMov = Input.GetAxisRaw("Vertical") * vMovSpeed;

        if (vMov >= 0.5f || vMov <= -0.5f) hMov = 0;
        else if (transform.localPosition.z > leftBound && Input.GetAxisRaw("Horizontal") < 0) hMov = 0; 
        else if (transform.localPosition.z < rightBound && Input.GetAxisRaw("Horizontal") > 0) hMov = 0;
        else hMov = Input.GetAxisRaw("Horizontal") * hMovSpeed;

        transform.Translate((Vector3.right * hMov + Vector3.up * vMov) * Time.deltaTime);
    }
}
