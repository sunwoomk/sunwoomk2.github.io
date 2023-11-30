using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStreetcar : MonoBehaviour
{
    int a = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 70)
        {
            a = 1;
        }

        else if (transform.position.y > 105)
        {
            a = -1;
        }

        transform.Translate(Vector3.up * 1.0f * Time.deltaTime * a * 3);
    }
}
