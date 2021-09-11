using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float camSpeed = 1f;
    public float camBorderThickness = 10f;

    public int camLimits;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - camBorderThickness)
        {
            pos.x += camSpeed + Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= camBorderThickness)
        {
            pos.x -= camSpeed + Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -camLimits, camLimits);

        transform.position = pos;
    }
}
