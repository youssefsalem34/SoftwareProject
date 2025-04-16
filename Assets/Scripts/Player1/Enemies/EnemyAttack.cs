using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float radius;

    public GameObject player;
    public AttributeManager playerHealth;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public bool attacking;
    public float attackDistance = 2f; // Distance to start attacking
    public float attackDamage = 20f; // Damage dealt per attack
    public float attackCooldown = 1f; // Time between attacks
    [SerializeField] private bool getHealth;

    private void Start()
    {
        
        //if (player != null)
        //{
           
        //}
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        if (player == null)
        {
            DetectingPlayerPresence();
        }
        else if(player != null && !getHealth)
        {
            playerHealth = player.GetComponent<AttributeManager>();
            getHealth = true;
        }
        if (player != null)
        {
          
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (this.gameObject.CompareTag("Enemy"))
            {
                if (distanceToPlayer <= attackDistance)
                {
                    if (!attacking)
                    {
                        attacking = true;
                        StartCoroutine(AttackPlayer());
                    }
                }
                else
                {
                    attacking = false; // Reset attacking if the player moves out of range
                }
            }
            else
            {
                StartCoroutine(KillEnemy());
            }

          
        }
    }

    private IEnumerator AttackPlayer()
    {
        while (attacking)
        {
            if (playerHealth != null )
            {
                playerHealth.ReduceHealth(attackDamage);
            }
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    private IEnumerator KillEnemy()
    {
        yield return new WaitForSeconds(8f);
        Destroy(this.gameObject);
    }



    void DetectingPlayerPresence()
    {
        Vector3 position = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            // Do something with each hit object
            if (hitCollider.gameObject.CompareTag("Player"))
            {
               player = hitCollider.gameObject;
            }
            

        }
    }
}