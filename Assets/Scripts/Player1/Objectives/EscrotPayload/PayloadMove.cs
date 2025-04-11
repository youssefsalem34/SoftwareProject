using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PayloadMove : MonoBehaviour
{

    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;
    public GameObject sixth;
    public GameObject seventh;
    public GameObject eighth;
    public bool firstCheckpoint;
    public bool secondCheckpoint;
    public bool thirdCheckpoint;
    public bool fourthCheckpoint;
    public bool fifthCheckpoint;
    public bool sixthCheckpoint;
    public bool seventhCheckpoint;
    public bool eighthCheckpoint;

    private float step;
    public float speed;


    public GameObject frontDoor;
    public GameObject floor;
    public OpenDoor frontDoorScript;
    public DetectPlayer floorDetect;
    // Start is called before the first frame update
    void Start()
    {
       // frontDoor = GameObject.Find("DoorFront");
        frontDoorScript = frontDoor.GetComponent<OpenDoor>();
        floorDetect = floor.GetComponent<DetectPlayer>();
        // second = GameObject.Find("obj2");
        // third = GameObject.Find("obj3");
        // fourth = GameObject.Find("obj4");
        // fifth = GameObject.Find("obj5"); 
        // sixth = GameObject.Find("obj6");
        // seventh = GameObject.Find("obj7");
        // eighth = GameObject.Find("obj8");
        secondCheckpoint = true;
        thirdCheckpoint = false;
        fourthCheckpoint = false;
        fifthCheckpoint = false;
        sixthCheckpoint = false;
        seventhCheckpoint = false;
        eighthCheckpoint = false;
        
    }

    // Update is called once per frame
    void Update()
    {

         step = speed * Time.deltaTime;
         PayloadMovement();
         PayloadDisctance();
    }
    

    void PayloadDisctance()
    {
        if (Vector3.Distance(this.transform.position, second.transform.position) < 1f)
        {
            secondCheckpoint = false;
            thirdCheckpoint = true;
            transform.LookAt(first.transform);
        }
        else if(Vector3.Distance(this.transform.position, third.transform.position) < 1f)
        {
            thirdCheckpoint = false;
            fourthCheckpoint = true;
            transform.LookAt(second.transform);

        }
        else if (Vector3.Distance(this.transform.position, fourth.transform.position) < 1f)
        {
            fourthCheckpoint = false;
            fifthCheckpoint = true;
            transform.LookAt(third.transform);


        }
        else if(Vector3.Distance(this.transform.position, fifth.transform.position) < 1f)
        {
            fifthCheckpoint = false;
            sixthCheckpoint = true;
            transform.LookAt(fourth.transform);

        }
        else if(Vector3.Distance(this.transform.position, sixth.transform.position) < 1f)
        {
            sixthCheckpoint = false;
            seventhCheckpoint = true;
            transform.LookAt(fifth.transform);


        }
        else if(Vector3.Distance(this.transform.position, seventh.transform.position) < 1f)
        {
            seventhCheckpoint = false;
            eighthCheckpoint = true;
            transform.LookAt(sixth.transform);


        }
        else if(Vector3.Distance(this.transform.position, eighth.transform.position) < 1f)
        {
            frontDoorScript.openDoor = true;
            floorDetect.roomDone = true;
            transform.LookAt(seventh.transform);

        }
    }

    void PayloadMovement()
    {
        if(secondCheckpoint == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, second.transform.position, step);
        }
        else if(thirdCheckpoint == true)
        {
            this.transform.position =  Vector3.MoveTowards(this.transform.position, third.transform.position, step);

        }
        else if(fourthCheckpoint == true)
        {
           this.transform.position = Vector3.MoveTowards(this.transform.position, fourth.transform.position, step);

        }
        else if(fifthCheckpoint == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, fifth.transform.position, step);

        }
        else if(sixthCheckpoint == true)
        {
           this.transform.position = Vector3.MoveTowards(this.transform.position, sixth.transform.position, step);

        }
        else if(seventhCheckpoint == true)
        {
           this.transform.position = Vector3.MoveTowards(this.transform.position, seventh.transform.position, step);

        }
        else if(eighthCheckpoint == true)
        {
           this.transform.position = Vector3.MoveTowards(this.transform.position, eighth.transform.position, step);

        }
    }
}
