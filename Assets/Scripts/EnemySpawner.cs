using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    // Enemy 프리팹 저장 배열

    [SerializeField]
    private GameObject boss;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };
    // Enemy X 위치 배열

    [SerializeField]
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
        // 코루틴, 원하는 만큼 시간을 정해서 다음 동작을 실행
        // IEnumerator 사용, ()안에 문자열 형태로 넣는다
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        // 몇초 기다리는 함수, 밑에 코드 실행하기 전 3초 후 실행

        float moveSpeed = 5f;

        int spawnCount = 0;
        
        int enemyIndex = 0;

        while(true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);

            }

            spawnCount++;
            if(spawnCount % 10 == 0)
            {
                enemyIndex++;
                moveSpeed += 2;
            }

            if(enemyIndex >= enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0;
                moveSpeed = 5f;
            }

            yield return new WaitForSeconds(spawnInterval);
            // 잠깐 쉬었다가 다시 foreach문 실행(1.5초 후에 실행)
        }

    }

    void SpawnEnemy(float posX, int index, float moveSpeed)      // Enemy생성, Enemy X 위치, Enemy의 몇번째 배열 생성
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        
        if(Random.Range(0, 5) == 0)
        {
            index += 1;
        }


        if(index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        // enemies[index] 해당 몇번째의 배열에 있는 enemies 생성, spawnPos위치에 생성
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        // enemyObject의 어떤 값을 꺼내기 위한 방법,  .GetComponent<Enemy>는 인스펙터에 있는 컴포넌트(Enemy 컴포넌트)
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }

}
