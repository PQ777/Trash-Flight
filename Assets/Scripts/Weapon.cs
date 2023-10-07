using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()    // Start()는 게임 객체를 비활성화 했다가 다시 활성화 하는 경우에도 호출된다
    {
        Destroy(gameObject, 1f);
        // 1초뒤 미사일 삭제, gameObject는 weapon
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
