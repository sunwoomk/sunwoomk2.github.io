using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject Camera;
    public CharacterController SelectPlayer;
    public float Speed = 10.0f;

    private float Gravity = 10.0f;
    private Vector3 MoveDir = Vector3.zero;
    private bool JumpButtonPressed = false;
    private bool FlyingMode = false;

    //public float rotateSpeed = 10.0f;

    public float JumpForce = 5.0f;

    //private bool isGround = true;

    Rigidbody body;

    float h, v;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Move();
        //Jump();

        if (SelectPlayer == null) return;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            var offset = Camera.transform.forward;
            offset.y = 0;
            transform.LookAt(SelectPlayer.transform.position + offset);
        }

        if (SelectPlayer.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);

            MoveDir *= Speed;

            if (JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                SelectPlayer.transform.rotation = Quaternion.Euler(0, 45, 0);
                JumpButtonPressed = true;
                MoveDir.y = JumpForce;
            }
        }
        else
        {
            if (MoveDir.y < 0 && JumpButtonPressed == false && Input.GetButton("Jump"))
            {
                FlyingMode = true;
            }

            if (FlyingMode)
            {
                JumpButtonPressed = true;

                MoveDir.y *= 0.95f;

                if (MoveDir.y > -1) MoveDir.y = -1;

                MoveDir.x = Input.GetAxis("Horizontal");
                MoveDir.z = Input.GetAxis("Vertical");
            }
            else
                MoveDir.y -= Gravity * Time.deltaTime;
        }

        if (!Input.GetButton("Jump"))
        {
            JumpButtonPressed = false;
            FlyingMode = false;
        }

        SelectPlayer.Move(MoveDir * Time.deltaTime);
    }

    /*
    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * Speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }

    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            body.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

            isGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lava")
        {
            Destroy(gameObject);
        }
    }
}
