using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    float xInput;
    float zInput;

    Vector3 moveVector;

    Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        GetInput();
        Move();
        Turn();
    }


    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
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


    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
