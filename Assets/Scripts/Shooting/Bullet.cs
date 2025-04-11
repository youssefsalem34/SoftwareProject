using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life;
    public GameObject player;
    public AttributeManager playerHealth;
    // Start is called before the first frame update
     void Awake()
    {
      //  Destroy(gameObject, life);
    }

    void Start()
    {
        // player = GameObject.Find("Player");
        // playerHealth = player.GetComponent<AttributeManager>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
           // playerHealth.ReduceHealth(30f);
           // Destroy(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
        
        //Destroy(collision.gameObject);
        
    }



}
