using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]        // public이든 private이든 인스펙터 안에서 확인하고 수정할 수 있다, 미사용하고 private할시 안보임
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;
    // 프리팹 저장, 플레이어, 웨폰등 GameObject이다

    [SerializeField]
    private Transform shootTransform;
    // Transform 클래스 추가. shootTransform의 위치, 회전, 스케일등을 사용할 수 있다.

    [SerializeField]
    private float shootInterval = 0.05f;
    // 미사일 쏘는 간격
    private float lastShotTime = 0f;
    // 최근에 쏜 미사일 시간

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //// 수평입력값 받는다, Input 클래스를 사용하고 GetAxisRaw() 안에 Horizontal 쓰면
        //// 왼쪽방향키 누르면 -1을 반환 오른쪽방향키 누르면 +1을 반환한다.
        ////float verticalInput = Input.GetAxisRaw("Vertical");
        //// 수직입력값 받는다

        //Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);

        //transform.position += moveTo * moveSpeed * Time.deltaTime;
        //// moveTo만 더해주면 속도가 느리기 움직이는 스피드변수 설정
        ///

        //Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position -= moveTo;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += moveTo;
        //}

        //Debug.Log(Input.mousePosition);
        // 마우스 좌표가 어디있는지 로그로 나온다
        // Input.mousePosition오 가져온 위치는 해상도 기준으로 나온다
        // 유니티에 보는 위치는 중앙이 (0,0) 이다.

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 좌표 변환하기, 해상도에서 보이는 좌표를 유니티에 있는 (0,0 ) 으로 변환해준다.

        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        // Mathf.Clamp(float value, float min, float max) 는 value가 min보다 작으면 min을 적용, max보다 크면 max 적용
        // 그게 아니면 value를 적용
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        // +=를 하면 계속 증가시키고 =를 하면 바로 그 값을 설정을 한다, 마우스 위치를 바로 설정

        Shoot();

    }

    void Shoot()        // 미사일 발사 메서드
    {
        if(Time.time - lastShotTime > shootInterval)
            // Time.time은 게임이 시작된 이후로 현재까지 흐른 시간
            // 
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            // 프리팹 불러오기, Inatantiate(Object original, Vector3 position, Quaternion rotation)
            // 어떤 오브젝트를 만들지, 위치, 회전을 설정하는 함수
            // shootTransform.position 발싸되는 위치, Quaternion.identity 아무회전없이 한다.

            lastShotTime = Time.time;
            // 지금 시간을 lastShotTime으로 넣는다.
        }

        /*
            10 - 0 > 0.05 이면 새로운 미사일 생성
            lastShotTime = 10;
            
            10.01 - 10 > 0.05 는 false
            10.02 - 10 > 0.05 false
            10.03 - 10 > 0.05 false
            10.06 - 10 > 0.05 true
            lastShotTime = 10.06
            띄엄띄엄 미사일이 발사된다.
         */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over");
            Destroy(gameObject);

        }
        else if(collision.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            // 게임매니저 싱글턴으로 쉽게 접근

            //Debug.Log("COin + 1");
            Destroy(collision.gameObject);
        }
    }


}
