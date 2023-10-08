using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;

    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    void Jump()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        // Rigidbody2D 가져오기, Rigidbody2D rigidBody 객체 가져오기

        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        jumpVelocity.x = Random.Range(-2f, 2f);

        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
        // 어떤 방향으로 힘을 준다, AddForce(얼만큼 힘으로 줄지, 모드를 어떻게 할지)
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY) // Enemy의 y좌표가 minY보다 작으면
        {
            Destroy(gameObject);
            // coin 삭제
        }
    }
}
