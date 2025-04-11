using UnityEngine;
using UnityEngine.UI;

public class PayloadHealth : MonoBehaviour
{
    public float radius;  // Radius of the sphere

    [SerializeField] private int health;
    [SerializeField] private Slider healthSlider;
     public bool isProtected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        CheckPayloadDeath();
    }


    void CheckPayloadDeath()
    {
        Vector3 sphereCenter = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(sphereCenter, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                if(health <= 0)
                {
                    PlayerDeath deathScript = hitCollider.gameObject.GetComponent<PlayerDeath>();
                    deathScript.playerDead = true;
                }
               
            }
        }
    }




    public int CheckHealth()
    {
        return health;
    }

    public int DeduceHealth(int m)
    {
        health -= m;
        return health;
    }
    public int AddHealth(int m)
    {
        health = m;
        return health;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
