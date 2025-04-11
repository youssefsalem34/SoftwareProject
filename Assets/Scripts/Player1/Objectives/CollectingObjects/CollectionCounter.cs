using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCounter : MonoBehaviour
{
    public int keyCounter;
    [SerializeField]private int requiredKeys;
    public GameObject frontDoor;
    public OpenDoor frontDoorScript;
    public GameObject floor;
    public DetectPlayer detectScript;
    // Start is called before the first frame update
    void Start()
    {
       // frontDoor = GameObject.Find("DoorFront");
        frontDoorScript = frontDoor.GetComponent<OpenDoor>();
        detectScript = floor.GetComponent<DetectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(keyCounter >=requiredKeys )
        {
            //Logic to unlock next room here
            frontDoorScript.openDoor = true;
            detectScript.roomDone = true;

        }
    }
}
