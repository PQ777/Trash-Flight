using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    // Enemy ������ ���� �迭

    [SerializeField]
    private GameObject boss;

    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };
    // Enemy X ��ġ �迭

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
        // �ڷ�ƾ, ���ϴ� ��ŭ �ð��� ���ؼ� ���� ������ ����
        // IEnumerator ���, ()�ȿ� ���ڿ� ���·� �ִ´�
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        // ���� ��ٸ��� �Լ�, �ؿ� �ڵ� �����ϱ� �� 3�� �� ����

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
            // ��� �����ٰ� �ٽ� foreach�� ����(1.5�� �Ŀ� ����)
        }

    }

    void SpawnEnemy(float posX, int index, float moveSpeed)      // Enemy����, Enemy X ��ġ, Enemy�� ���° �迭 ����
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
        // enemies[index] �ش� ���°�� �迭�� �ִ� enemies ����, spawnPos��ġ�� ����
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        // enemyObject�� � ���� ������ ���� ���,  .GetComponent<Enemy>�� �ν����Ϳ� �ִ� ������Ʈ(Enemy ������Ʈ)
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }

}
