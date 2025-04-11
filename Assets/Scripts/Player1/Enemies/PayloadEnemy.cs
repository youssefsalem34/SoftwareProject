using UnityEngine;

public class PayloadEnemy : MonoBehaviour
{
   // [SerializeField] private GameObject payload;
    [SerializeField] private int detectionRadius;
    [SerializeField] private float enemySpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookForPayload();
    }

    void LookForPayload()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, detectionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("ThirdObjective"))
            {

                float speed = enemySpeed; // Set your desired speed
                float step = speed * Time.deltaTime; // Calculate distance to move per frame
                this.transform.position = Vector3.MoveTowards(this.transform.position, hitCollider.transform.position, step);

            }
        }

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ThirdObjective"))
        {
           PayloadHealth health = collision.gameObject.GetComponent<PayloadHealth>();
            AudioSource soundEffect = collision.gameObject.GetComponent<AudioSource>();
            health.DeduceHealth(2);
            soundEffect.Play();
            Destroy(this.gameObject);
        }
        //else if (collision.gameObject.CompareTag("Shield"))
        //{
        //    ShieldColl shield = collision.gameObject.GetComponent<ShieldColl>();
        //    shield.shieldOff = true;
        //    Destroy(this.gameObject);  
                
            
        //}
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
