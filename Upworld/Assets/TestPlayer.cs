using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    
    public bool fastRun = false;
    public bool isJump = false;
    public Animator animator;
    public Rigidbody rigid;
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        jumpPower = 6.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        FastRunCheck();
        Move();
        Jump();




    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))

        {
            if (fastRun == true)
            {
                Debug.Log("FastRun���� WŰ ����");
                animator.SetBool("FastRun",true);
            }
            else if (fastRun == false)
            {
                Debug.Log("Run���� WŰ ����");
                animator.SetBool("Run", true);
                animator.SetBool("FastRun", false);
            }
            

        }
        else if (Input.GetKey(KeyCode.A))

        {

            if (fastRun == true)
            {
                Debug.Log("FastRun���� AŰ ����");
                animator.SetBool("FastRun", true);
            }
            else if (fastRun == false)
            {
                Debug.Log("Run���� AŰ ����");
                animator.SetBool("Run", true);
                animator.SetBool("FastRun", false);
            }

        }
        else if (Input.GetKey(KeyCode.S))

        {

            if (fastRun == true)
            {
                Debug.Log("FastRun���� SŰ ����");
                animator.SetBool("FastRun", true);
            }
            else if (fastRun == false)
            {
                Debug.Log("Run���� SŰ ����");
                animator.SetBool("Run", true);
                animator.SetBool("FastRun", false);
            }

        }
        else if (Input.GetKey(KeyCode.D))

        {

            if (fastRun == true)
            {
                Debug.Log("FastRun���� DŰ ����");
                animator.SetBool("FastRun", true);
            }
            else if (fastRun == false)
            {
                Debug.Log("Run���� DŰ ����");
                animator.SetBool("Run", true);
                animator.SetBool("FastRun", false);
            }

        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("�̵�Ű���� �� ��");
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
        animator.SetFloat("AGravity",this.rigid. velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))

        {
            Debug.Log("�������� �����̽� Ű ����");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
            animator.SetBool("Jump", false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = true;
            animator.SetBool("Jump", true);
        }
    }
}
