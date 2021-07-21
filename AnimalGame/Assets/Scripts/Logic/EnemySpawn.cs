using System.Collections;
using UnityEngine;

/*
 * @class EnemySpawn
 * @desc  적군 소환 클래스
 * @author 정성호
 * @date  2021-07-15
 */

public class EnemySpawn : MonoBehaviour
{
    public Enemy enemy;

    private MemoryPool memoryPool;
    private GameObject[] enemyArray;
    private int enemyMaxPool = 10;
    private bool enemyState = false;


    private Logic logic;

    private void Awake(){
        logic=GameObject.Find("Logic").gameObject.GetComponent<Logic>();
    }

    void Start(){
        enemyState = true;
        memoryPool = new MemoryPool();
        memoryPool.Create(enemy.enemyObject, enemyMaxPool);
        enemyArray = new GameObject[enemyMaxPool];
    }

    void Update(){

        // 양동건
        // 예외 처리.
        if (logic.state != Logic.GameState.PLAY) return;

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (enemyState)
        {
            StartCoroutine(ItemCycleControl());

            for (int i = 0; i < enemyMaxPool; i++)
            {
                if (enemyArray[i] == null)
                {
                    enemyArray[i] = memoryPool.NewItem();

                    Vector2 vector = Vector2.zero;
                    vector.x = Random.Range(-2f, 2f);
                    vector.y = 5f;

                    enemy.enemyLocation.transform.position = vector;
                    enemyArray[i].transform.position = enemy.enemyLocation.transform.position;

                    break;
                }
            }
        }

        for (int i = 0; i < enemyMaxPool; i++)
        {
            if (enemyArray[i])
            {
                if (enemyArray[i].GetComponent<Collider2D>().enabled == false)
                {
                    enemyArray[i].GetComponent<Collider2D>().enabled = true;
                    memoryPool.RemoveItem(enemyArray[i]);
                    enemyArray[i] = null;
                }
            }
        }
    }

    IEnumerator ItemCycleControl()
    {
        enemyState = false;
        yield return new WaitForSeconds(3f);
        enemyState = true;
    }
}
