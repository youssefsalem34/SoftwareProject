using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public GameObject secondObjective;
    [SerializeField] GameObject key;
    public CollectionCounter collectionInt;
    [SerializeField] private float radius;
    

    private bool hasCollected = false;

    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        secondObjective = null;
        FindTheObjective();
        if(secondObjective != null)
        {
            collectionInt = secondObjective.GetComponent<CollectionCounter>();
        }
        else
        {
            Destroy(key.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!hasCollected && col.gameObject.CompareTag("Player"))
        {
            CollectSound soundScript = col.gameObject.GetComponent<CollectSound>();
            soundScript.collect = true;
            hasCollected = true;
            collectionInt.keyCounter += 1;
            Destroy(key.gameObject);
        }
    }

    void FindTheObjective()
    {
        
        Vector3 position = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("SecondObjective"))
            {
                secondObjective = hitCollider.gameObject;
            }
        }
        System.Array.Clear(hitColliders, 0, hitColliders.Length);
    }
}
