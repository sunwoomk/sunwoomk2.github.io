using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject Target;

    public float xmove = 0;
    public float ymove = 0;
    public float distance = 3;

    //public float offsetX = 0.0f;
    //public float offsetY = 10.0f;
    //public float offsetZ = -10.0f;

    //public float CameraSpeed = 10.0f;
    //Vector3 TargetPos;

    void FixedUpdate()
    {
        /*
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

        */

        xmove += Input.GetAxis("Mouse X");
        ymove -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(ymove, xmove, 0);
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        transform.position = Target.transform.position - transform.rotation * reverseDistance;
    }
}
