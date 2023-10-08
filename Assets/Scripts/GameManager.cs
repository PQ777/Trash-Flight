using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// TextMeshProUGUI 사용시 선언

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    // 싱글턴

    [SerializeField]
    private TextMeshProUGUI text;

    private int coin = 0;
    // 코인 개수

    void Awake()    // start 보다 더 빠르게 실행된다
    {
        if(instance == null)
        {
            instance = this;
            // 게임매니저를 instance에 넣는다(자기자신 호출)
            // 다른 클래스에서 GameManager.instance.함수 로 접근할 수 있다
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());
        // 텍스트에 표시, SetText는 문자열로 가능하니 정수로 표시할려면 ToString() 사용

        if(coin % 30 == 0)
        {
            Player player = FindObjectOfType<Player>();
            // Player를 얻어와야 되는데 IncreaseCoin는 전달받는 값이 없다
            // 오브젝트를 찾아서 사용할 수 있는 방법은 FindObjectOfType<>이 있다.
            
            if(player != null)
            {
                player.Upgrade();
            }
        }
    }

}
