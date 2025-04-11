using UnityEngine;

public class ShieldColl : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private ShieldMechanic shieldScript;
    [SerializeField] public bool shieldOff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldOff)
        {
            shieldScript.shieldOn = false;
            shieldOff = false;
        }


        CheckForEnemy2();
    }


    void CheckForEnemy2()
    {
        Vector3 sphereCenter = this.transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(sphereCenter, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy2"))
            {
                Destroy(hitCollider.gameObject);
                this.gameObject.SetActive(false);
                shieldOff = true;
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
