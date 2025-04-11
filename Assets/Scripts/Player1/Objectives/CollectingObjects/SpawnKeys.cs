using UnityEngine;

public class SpawnKeys : MonoBehaviour
{
    public int keysToSpawn;
    public int keysSpawned;
    public GameObject keys;
    public float spawnRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keys = Resources.Load("Key") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        while(keysSpawned < keysToSpawn)
        {
            keysSpawned += 1;
            SpawnKey();
        }
    }

    void SpawnKey()
    {
        // Vector3 randomSpawnPosition = new Vector3(Random.Range(-46, 47), 5, Random.Range(-50,50));
        // Get the object's position (where the script is attached)
        Vector3 objectPosition = transform.position;

        // Calculate a random position around the object within the given radius
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 randomSpawnPosition = new Vector3(randomCircle.x, 0, randomCircle.y) + objectPosition;

        // Set the Y coordinate for spawning (height) to match the object's height or a fixed value
        randomSpawnPosition.y = objectPosition.y + 1;
        Instantiate(keys, randomSpawnPosition, Quaternion.identity); 
    }
}
