using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public GameObject parent;
    TestPlayer testPlayer;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        testPlayer = parent.GetComponent<TestPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        
    }*/
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            testPlayer.isGround = true;
            testPlayer.animator.SetBool("Jump", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            testPlayer.isGround = false;
            testPlayer.animator.SetBool("Jump", true);
        }
    }
}
