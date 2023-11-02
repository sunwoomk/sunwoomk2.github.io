using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public float Speed = 5.0f;
    public float rotateSpeed = 10.0f;
    public float JumpForce = 5.0f;
    private bool isGround = true;
    public bool fastRun = false;
    public bool isJump = false;
    public Animator animator;
    public Rigidbody rigid;
    public float jumpPower;
    public GameObject saveLocation;
    public bool isSkill;
    
    float h, v;

    // Start is called before the first frame update
    void Start()
    {
        isSkill = false;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        jumpPower = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        FastRunCheck();
        Move();
        Jump();
        Skill();




    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0) && fastRun == false)
        {
            transform.position += dir * Speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
        else if (!(h == 0 && v == 0) && fastRun == true)
        {
            transform.position += dir * Speed * 1.5f * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))

        {
            if (fastRun == true)
            {
                Debug.Log("FastRun상태 WASD키 누름");
                animator.SetBool("FastRun", true);
            }
            else if (fastRun == false)
            {
                Debug.Log("Run상태 WASD키 누름");
                animator.SetBool("Run", true);
                animator.SetBool("FastRun", false);
            }
        }
        else
        {
            Debug.Log("이동키에서 손 뗌");
            animator.SetBool("Run", false);
            animator.SetBool("FastRun", false);
        }
        
    }
    void FastRunCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            fastRun = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            fastRun = false;
        }
    }

    void Jump()
    {
        animator.SetFloat("AGravity", this.rigid.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)

        {
            Debug.Log("점프상태 스페이스 키 누름");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGround = false;
        }

    }

    void Skill()
    {
        if (Input.GetKey(KeyCode.Z) && isSkill == false)
        {
            saveLocation.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        }
        if (Input.GetKey(KeyCode.X) && isSkill == false)
        {
            this.transform.position = saveLocation.transform.position;
            isSkill = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
            animator.SetBool("Jump", false);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
            animator.SetBool("Jump", true);
        }
    }
}
