using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()    // Start()�� ���� ��ü�� ��Ȱ��ȭ �ߴٰ� �ٽ� Ȱ��ȭ �ϴ� ��쿡�� ȣ��ȴ�
    {
        Destroy(gameObject, 1f);
        // 1�ʵ� �̻��� ����, gameObject�� weapon
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
