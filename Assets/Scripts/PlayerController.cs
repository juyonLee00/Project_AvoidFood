using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    float xInput;
    float zInput;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        //게임오브젝트에서 컴포넌트를 찾아서 가져오므로 직접 할당할 필요x
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMover();
    }

    void PlayerMover()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(xInput, 0f, zInput).normalized;
        transform.position += moveVector * Time.deltaTime * speed;

        animator.SetBool("isRun", moveVector != Vector3.zero);

        transform.LookAt(transform.position + moveVector);
    }

    //죽었을 경우 오브젝트 비활성화
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
