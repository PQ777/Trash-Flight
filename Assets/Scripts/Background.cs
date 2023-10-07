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
        // �Ʒ������� ��� ������, Vector3�� ����ü, ������ ����
        // Vector3�� .�� ����ϸ� down, left, up, right���� �Ӽ� ��� ����
        // Time.deltaTime ���ɿ� ������� �Ȱ��� ��ġ�� �̵�����

        if (transform.position.y < -10)     // position�� y���� -10���� ������
        {
            transform.position += new Vector3(0, 20f, 0);
            // new Vector3()�� ���ο� Vector3 ����
        }

    }
}
