using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField]private float radius;
    [SerializeField]private GameObject spawnEnemy;
    public bool roomDone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectingPlayerPresence();
    }

    void DetectingPlayerPresence()
    {
        Vector3 position = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            // Do something with each hit object
            if(hitCollider.gameObject.CompareTag("Player"))
            {
                spawnEnemy.SetActive(true);
            }
            else if(hitCollider.gameObject.CompareTag("Enemy")  && roomDone) //|| hitCollider.gameObject.CompareTag("Enemy2")
            {
                //Killing enemies after room is finished
                Destroy(hitCollider.gameObject);
            }
            else if (hitCollider.gameObject.CompareTag("EnemyDanger") && roomDone) //|| hitCollider.gameObject.CompareTag("Enemy2")
            {
                //Killing enemies after room is finished
                Destroy(hitCollider.gameObject);
            }

        }
    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
