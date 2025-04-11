using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfEnemyDead : MonoBehaviour
{
    public GameObject firstObjective;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        firstObjective = GameObject.Find("FirstObjective");
        if (firstObjective == null)
        {
            Debug.Log("No Objective");
        }
        else
        {
            
        }
    }
}
