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
        // Rigidbody2D ��������, Rigidbody2D rigidBody ��ü ��������

        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        jumpVelocity.x = Random.Range(-2f, 2f);

        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
        // � �������� ���� �ش�, AddForce(��ŭ ������ ����, ��带 ��� ����)
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY) // Enemy�� y��ǥ�� minY���� ������
        {
            Destroy(gameObject);
            // coin ����
        }
    }
}
