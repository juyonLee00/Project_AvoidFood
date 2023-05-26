using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

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
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 playerVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = playerVelocity;
    }

    //죽었을 경우 오브젝트 비활성화
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
