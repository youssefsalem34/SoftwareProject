using UnityEngine;

public class ManageDangerScript : MonoBehaviour
{
    [SerializeField]private SpawnDangerEnemies spawnDangerEnemies;
    [SerializeField] private GameObject firstObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firstObj.gameObject.activeSelf)
        {
            spawnDangerEnemies.enabled = true;
        }
        else
        {
            spawnDangerEnemies.enabled = false;
        }
    }
}
