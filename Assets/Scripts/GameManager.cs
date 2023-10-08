using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// TextMeshProUGUI ���� ����

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    // �̱���

    [SerializeField]
    private TextMeshProUGUI text;

    private int coin = 0;
    // ���� ����

    void Awake()    // start ���� �� ������ ����ȴ�
    {
        if(instance == null)
        {
            instance = this;
            // ���ӸŴ����� instance�� �ִ´�(�ڱ��ڽ� ȣ��)
            // �ٸ� Ŭ�������� GameManager.instance.�Լ� �� ������ �� �ִ�
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());
        // �ؽ�Ʈ�� ǥ��, SetText�� ���ڿ��� �����ϴ� ������ ǥ���ҷ��� ToString() ���
    }

}
