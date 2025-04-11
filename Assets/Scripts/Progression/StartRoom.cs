using UnityEngine;
using System.Collections.Generic; 

public class StartRoom : MonoBehaviour
{
    public GameObject backDoor;
    public CloseDoor closeBool;
    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject objective;
    public List<GameObject> objectsToPickFrom = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
           objective1.SetActive(false);
        objective2.SetActive(false);
        objective3.SetActive(false);

    }
    void Start()
    {
        closeBool = backDoor.GetComponent<CloseDoor>();
     

        int randomIndex = Random.Range(0, objectsToPickFrom.Count);
            objective = objectsToPickFrom[randomIndex];

            objective.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            closeBool.isClose = true;
            objective.SetActive(true);
            SwitchBetweenWeapons switchScript = col.gameObject.GetComponent<SwitchBetweenWeapons>();
            switchScript.upgradeTime = true;
            this.gameObject.SetActive(false);

        }
    }
}
