using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject Target;

    public float xmove = 0;
    public float ymove = 0;

    public float distance = 10;
    public float x;

    

    void Update()
    {
        Vector3 camAngle = this.transform.rotation.eulerAngles;
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        xmove += Input.GetAxis("Mouse X") * Time.deltaTime;
        ymove -= Input.GetAxis("Mouse Y") * Time.deltaTime;
        x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        transform.rotation = Quaternion.Euler(x, (camAngle.y+ mouseDelta.x), camAngle.z);

        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        transform.position = Target.transform.position - transform.rotation * reverseDistance;
    }
}
