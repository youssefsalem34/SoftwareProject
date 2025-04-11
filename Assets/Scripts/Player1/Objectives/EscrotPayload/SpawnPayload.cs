using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPayload : MonoBehaviour
{
        public GameObject payload;
        public GameObject first;

    // Start is called before the first frame update
    void Start()
    {
        //first = GameObject.Find("obj1");
       // payload = Resources.Load("Payload") as GameObject;
         if(first != null)
        {
           //  Instantiate(payload, first.transform.position, Quaternion.identity);
           payload.SetActive(true);
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);

    }
}
