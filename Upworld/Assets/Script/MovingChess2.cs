using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingChess2 : MonoBehaviour
{
    public GameObject King;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (King == null)
        {
            if (transform.position.y < 180)
            {
                transform.Translate(Vector3.up * 1.0f * Time.deltaTime);
            }
        }
    }
}
