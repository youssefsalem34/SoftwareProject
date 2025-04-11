using UnityEngine;

public class BlasterBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ThirdObjective"))
        {
            ShieldMechanic shield = collision.gameObject.GetComponent<ShieldMechanic>();
            shield.shieldOn = true;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
