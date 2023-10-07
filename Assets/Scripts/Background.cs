using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        // 아래쪽으로 계속 내린다, Vector3는 구조체, 값들의 묶음
        // Vector3에 .을 사용하면 down, left, up, right같은 속성 사용 가능
        // Time.deltaTime 성능에 상관없이 똑같은 위치에 이동가능

        if (transform.position.y < -10)     // position에 y값이 -10보다 작으면
        {
            transform.position += new Vector3(0, 20f, 0);
            // new Vector3()는 새로운 Vector3 생성
        }

    }
}
