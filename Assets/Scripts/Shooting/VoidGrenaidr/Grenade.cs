using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject voidZonePrefab;
    public float explosionDelay = 1.5f;

    void Start()
    {
        Invoke("Explode", explosionDelay);
        voidZonePrefab = Resources.Load("VoidZone") as GameObject;
    }

    void Explode()
    {
        Instantiate(voidZonePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // Destroy grenade object after explosion
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
         Explode(); // Trigger explosion on impact

        }
    }
}