using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;
    // ȭ�鿡 ������ �ʴ� �Ʒ� ��ġ

    [SerializeField]
    private float hp = 1f;
    // Enemy ü��

    public void SetMoveSpeed(float moveSpeed)   
    {
        this.moveSpeed = moveSpeed;
        // this�� ��(.)�� ����ϸ� �ش� Ŭ������ �ִ� ������ ����Ų��
        // ���� �̸��� ������ this.�����̸� �� ����Ѵ�.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if(transform.position.y < minY) // Enemy�� y��ǥ�� minY���� ������
        {
            Destroy(gameObject);
            // Enemy ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     // IsTrigger üũ�϶� ���
    {
        if(collision.gameObject.tag == "Weapon")    // collision.gameObject: Enemy�� �浹�� � ������Ʈ, .tag�� weapon�϶�
        {
            Weapon weapon = collision.gameObject.GetComponent<Weapon>();
            // Weapon Ŭ������ weapon ����, collision.gameObject: �浹�� ������κ��� GetComponent<Weapon> Weapon ������Ʈ �����´�.
            hp -= weapon.damage;

            if(hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }

            Destroy(collision.gameObject);
        }
    }
}
