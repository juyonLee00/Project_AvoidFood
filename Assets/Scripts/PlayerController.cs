using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public float speed = 8f;
    public float jumpPower = 6f;
    float xInput;
    float zInput;
    bool jDown;

    bool isJump;

    Vector3 moveVector;

    Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }


    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        jDown = Input.GetButtonDown("Jump");
    }


    void Move()
    {
        moveVector = new Vector3(xInput, 0f, zInput).normalized;
        transform.position += moveVector * Time.deltaTime * speed;

        animator.SetBool("isRun", moveVector != Vector3.zero);
    }


    void Turn()
    {
        transform.LookAt(transform.position + moveVector);
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
            animator.SetTrigger("doJump");
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
