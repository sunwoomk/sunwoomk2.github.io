using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public AudioClip walkSound;
    public AudioClip runSound;
    public AudioSource audioSource;
    public GameObject cam;

    public GameObject child;
    public float Speed = 5.0f;
    public float fast_Speed = 10.0f;

    public float rotateSpeed = 10.0f;

    public float JumpForce = 5.0f;

    public bool isGround = true;

    float h, v;

    public bool fastRun = false;
    public bool isJump = false;
    public Animator animator;
    public Rigidbody rigid;

    public bool useSkill = false;
    public GameObject teleportPoint;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.loop = true;
        child = gameObject.transform.GetChild(0).gameObject;
        JumpForce = 6.0f;
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))

        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(h, 0, v);

            Vector3 lookForward = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z).normalized;
            Vector3 lookRight = new Vector3(cam.transform.right.x, 0f, cam.transform.right.z).normalized;
            
            Vector3 camDir = lookForward * dir.z + lookRight * dir.x;
            this.transform.forward = camDir;




            if (fastRun == true)
            {
                Debug.Log("FastRun상태 WASD키 누름");
                animator.SetBool("FastRun", true);
                if (!(h == 0 && v == 0))
                {
                    transform.position += camDir.normalized * fast_Speed * Time.deltaTime;
                    if (audioSource.clip != runSound && isGround == true)
                    {
                        audioSource.clip = runSound;
                        audioSource.Play();
                    }
                }
            }
            else if (fastRun == false)
            {
                Debug.Log("Run상태 WASD키 누름");
                animator.SetBool("Run", true);
                animator.SetBool("FastRun", false);
                if (!(h == 0 && v == 0))
                {
                    transform.position += camDir * Speed * Time.deltaTime;
                    if (audioSource.clip != walkSound && isGround == true)
                    {
                        audioSource.clip = walkSound;
                        audioSource.Play();
                    }
                    

                }
            }
            

        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("이동키에서 손 뗌");
            animator.SetBool("Run", false);
            animator.SetBool("FastRun", false);
            audioSource.Stop();
            audioSource.clip = null;
        }
        if (isGround == false)
        {
            audioSource.Stop();
            audioSource.clip = null;
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
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)

        {
            Debug.Log("점프상태 스페이스 키 누름");
            rigid.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

            isGround = false;
        }

    }

    

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("Jump", true);
        }
    }*/

    private void Skill()
    {


        if (!useSkill && Input.GetKey(KeyCode.Z))
        {

            position = this.transform.position;
            position.y = position.y + 0.3f;
            teleportPoint.transform.position = position;

        }
        else if (!useSkill && Input.GetKey(KeyCode.X))
        {

            this.transform.position = teleportPoint.transform.position;
            useSkill = true;
        }
    }
}
