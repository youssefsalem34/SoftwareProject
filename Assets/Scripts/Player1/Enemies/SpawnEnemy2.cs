using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy2 : MonoBehaviour
{
    public List<GameObject> enemySpawners = new List<GameObject>();
    public GameObject enemyManager;

    public GameObject enemy1;
    public int index;


    private System.Random random;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random = new System.Random();
        enemy1 = Resources.Load("Enemy2") as GameObject;
        StartCoroutine(SpawningEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        index = random.Next(enemySpawners.Count);
        enemyManager = enemySpawners[index];
    }


    void SpawnEnemy()
    {
        Instantiate(enemy1, enemyManager.transform.position, Quaternion.identity);
    }

    private IEnumerator SpawningEnemies()
    {

        // for(int i = 0; i < 9; i++)
        while (true)
        {
            yield return new WaitForSeconds(5f);
            SpawnEnemy();

        }
    }
}
