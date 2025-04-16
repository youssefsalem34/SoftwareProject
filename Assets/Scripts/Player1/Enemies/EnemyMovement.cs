using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform playerPosition;
    private AttributeManager enemyHealth;
    public Animator animator;

    [Header("Enemy Settings")]
    public float speed;
    public float detectionRadius;

    [Header("Objective Settings")]
    public GameObject firstObjective;
    private EliminateEnemies enemyKilledCounter;

    private bool isPlayerDetected = false;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<AttributeManager>();
       // animator = GetComponent<Animator>();

        if (nav == null)
        {
            Debug.LogError("NavMeshAgent component is missing on " + gameObject.name);
            enabled = false;
            return;
        }

        if (enemyHealth == null)
        {
            Debug.LogError("AttributeManager component is missing on " + gameObject.name);
            enabled = false;
            return;
        }

        if (animator == null)
        {
            Debug.LogError("Animator component is missing on " + gameObject.name);
            enabled = false;
            return;
        }

        firstObjective = GameObject.Find("FirstObjective");
        if (firstObjective != null)
        {
            enemyKilledCounter = firstObjective.GetComponent<EliminateEnemies>();
        }
        else
        {
            Debug.Log("FirstObjective not found in the scene.");
        }

        FindPlayer();
    }

    void Update()
    {
        if (playerPosition == null)
        {
            FindPlayer();
        }

        if (playerPosition != null)
        {
            nav.SetDestination(playerPosition.position);

            if (!isPlayerDetected)
            {
                isPlayerDetected = true;
                animator.SetBool("isRunning", true); // Activate running animation
            }
        }
        else if (isPlayerDetected)
        {
            isPlayerDetected = false;
            animator.SetBool("isRunning", false); // Stop running animation
        }

        CheckHealthStatus();
    }

    void FindPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                playerPosition = hitCollider.transform;
                return;
            }
        }

        if (playerPosition == null)
        {
            Debug.LogWarning("Player not found within detection radius.");
        }
    }

    void CheckHealthStatus()
    {
        if (enemyHealth.enemyHealth <= 0 && this.gameObject.CompareTag("Enemy"))
        {
            if (enemyKilledCounter != null)
            {
                enemyKilledCounter.numberOfEnemiesKilled++;
            }

            Destroy(gameObject);
        }
        else if (enemyHealth.enemyHealth <= 0 && this.gameObject.CompareTag("EnemyDanger"))
        {
            AttributeManager playerHealth = playerPosition.gameObject.GetComponent<AttributeManager>();
            playerHealth.ReduceHealth(15f);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            enemyHealth.ReduceEnemyHealth(20f);
            Destroy(col.gameObject); // Destroy bullet on impact
        }
       
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}