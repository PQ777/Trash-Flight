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
    // 화면에 보이지 않는 아래 위치

    [SerializeField]
    private float hp = 1f;
    // Enemy 체력

    public void SetMoveSpeed(float moveSpeed)   
    {
        this.moveSpeed = moveSpeed;
        // this에 점(.)을 사용하면 해당 클래스에 있는 변수를 가리킨다
        // 변수 이름이 같을때 this.변수이름 을 사용한다.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if(transform.position.y < minY) // Enemy의 y좌표가 minY보다 작으면
        {
            Destroy(gameObject);
            // Enemy 삭제
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     // IsTrigger 체크일때 사용
    {
        if(collision.gameObject.tag == "Weapon")    // collision.gameObject: Enemy와 충돌한 어떤 오브젝트, .tag가 weapon일때
        {
            Weapon weapon = collision.gameObject.GetComponent<Weapon>();
            // Weapon 클래스를 weapon 변수, collision.gameObject: 충돌한 대상으로부터 GetComponent<Weapon> Weapon 컴포넌트 가져온다.
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
