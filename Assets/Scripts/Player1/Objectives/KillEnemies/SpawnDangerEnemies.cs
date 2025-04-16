using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDangerEnemies : MonoBehaviour
{
    public List<GameObject> enemySpawners = new List<GameObject>();
    public GameObject enemyManager;

    public GameObject enemy1;
    public int index;
    [SerializeField] float enemiesPerSecond;

    private System.Random random;
    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        enemy1 = Resources.Load("EnemyDanger") as GameObject;
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
            yield return new WaitForSeconds(enemiesPerSecond);
            SpawnEnemy();

        }
    }
}
