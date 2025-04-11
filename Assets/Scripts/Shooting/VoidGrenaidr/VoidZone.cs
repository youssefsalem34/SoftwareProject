using UnityEngine;

public class VoidZone : MonoBehaviour
{
    public float duration;
    [SerializeField] private float damageToEnemies;
    [SerializeField] private float upwardForce; // The force to apply upwards
    
    private float time;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void OnTriggerStay(Collider other)
    {
        time = Time.deltaTime;
        if (other.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            AttributeManager enemy = other.GetComponent<AttributeManager>();
            if (enemy != null)
            {
                enemy.ReduceEnemyHealth(damageToEnemies);
            }

            // Add upward force
            Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                enemyRigidbody.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Add additional behavior for exiting enemies if needed
        }
    }
}