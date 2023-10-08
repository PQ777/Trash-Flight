using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]        // public�̵� private�̵� �ν����� �ȿ��� Ȯ���ϰ� ������ �� �ִ�, �̻���ϰ� private�ҽ� �Ⱥ���
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;
    // ������ ����, �÷��̾�, ������ GameObject�̴�

    [SerializeField]
    private Transform shootTransform;
    // Transform Ŭ���� �߰�. shootTransform�� ��ġ, ȸ��, �����ϵ��� ����� �� �ִ�.

    [SerializeField]
    private float shootInterval = 0.05f;
    // �̻��� ��� ����
    private float lastShotTime = 0f;
    // �ֱٿ� �� �̻��� �ð�

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //// �����Է°� �޴´�, Input Ŭ������ ����ϰ� GetAxisRaw() �ȿ� Horizontal ����
        //// ���ʹ���Ű ������ -1�� ��ȯ �����ʹ���Ű ������ +1�� ��ȯ�Ѵ�.
        ////float verticalInput = Input.GetAxisRaw("Vertical");
        //// �����Է°� �޴´�

        //Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);

        //transform.position += moveTo * moveSpeed * Time.deltaTime;
        //// moveTo�� �����ָ� �ӵ��� ������ �����̴� ���ǵ庯�� ����
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
        // ���콺 ��ǥ�� ����ִ��� �α׷� ���´�
        // Input.mousePosition�� ������ ��ġ�� �ػ� �������� ���´�
        // ����Ƽ�� ���� ��ġ�� �߾��� (0,0) �̴�.

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ��ǥ ��ȯ�ϱ�, �ػ󵵿��� ���̴� ��ǥ�� ����Ƽ�� �ִ� (0,0 ) ���� ��ȯ���ش�.

        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        // Mathf.Clamp(float value, float min, float max) �� value�� min���� ������ min�� ����, max���� ũ�� max ����
        // �װ� �ƴϸ� value�� ����
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);
        // +=�� �ϸ� ��� ������Ű�� =�� �ϸ� �ٷ� �� ���� ������ �Ѵ�, ���콺 ��ġ�� �ٷ� ����

        Shoot();

    }

    void Shoot()        // �̻��� �߻� �޼���
    {
        if(Time.time - lastShotTime > shootInterval)
            // Time.time�� ������ ���۵� ���ķ� ������� �帥 �ð�
            // 
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            // ������ �ҷ�����, Inatantiate(Object original, Vector3 position, Quaternion rotation)
            // � ������Ʈ�� ������, ��ġ, ȸ���� �����ϴ� �Լ�
            // shootTransform.position �߽εǴ� ��ġ, Quaternion.identity �ƹ�ȸ������ �Ѵ�.

            lastShotTime = Time.time;
            // ���� �ð��� lastShotTime���� �ִ´�.
        }

        /*
            10 - 0 > 0.05 �̸� ���ο� �̻��� ����
            lastShotTime = 10;
            
            10.01 - 10 > 0.05 �� false
            10.02 - 10 > 0.05 false
            10.03 - 10 > 0.05 false
            10.06 - 10 > 0.05 true
            lastShotTime = 10.06
            ������ �̻����� �߻�ȴ�.
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
            // ���ӸŴ��� �̱������� ���� ����

            //Debug.Log("COin + 1");
            Destroy(collision.gameObject);
        }
    }


}
