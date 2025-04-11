// using UnityEngine;

// public class StopPreviousRoom : MonoBehaviour
// {
//     public GameObject floor1;
//     public GameObject floor2;
//     public GameObject floor3;
//     public GameObject floor4;
//     public GameObject floor5;
//     public bool floor1Active;
//     public bool floor2Active;
//     public bool floor3Active;
//     public bool floor4Active;
//     public bool floor5Active;

//     public GameObject roomCounter;
//     public AttributeManager roomCounterScript;
    
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         // roomCounter = GameObject.Find("Player");
//         // roomCounterScript = roomCounter.GetComponent<AttributeManager>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         roomCounter = GameObject.FindWithTag("Player");
//         if (roomCounter == null)
//         {
//             Debug.Log("Cant find player");
//         }
//         else if(roomCounter != null)
//         {
//             roomCounterScript = roomCounter.GetComponent<AttributeManager>();
//             ControlRoomCount();
//         }
//         else{

//         }
      
//     }

//     void ControlRoomCount()
//     {
//           if (floor1 == null)
//         {

//         }
//         else if(floor2 == null)
//         {

//         }
//         else if(floor3 == null)
//         {
            
//         }
//         else if(floor4 == null)
//         {
            
//         }
//         else if(floor5 == null)
//         {
            
//         }
//         if(roomCounterScript.roomsCount == 1)
//         {
//             floor1Active = true;
//         }
//         else if((roomCounterScript.roomsCount == 2))
//         {
//             floor2Active = true;
//         }
//         else if(roomCounterScript.roomsCount == 3)
//         {
//             floor3Active = true;
//         }
//         else if(roomCounterScript.roomsCount == 4)
//         {
//             floor4Active = true;
//         }
//     }

//     void OnTriggerEnter(Collider col)
//     {
//         if(col.CompareTag("Player") && floor1Active == true)
//         {
//             floor1.SetActive(false);
//             floor1Active = false;
//         }
//         else if(col.CompareTag("Player") && floor2Active == true)
//         {
//             floor2.SetActive(false);
//             floor2Active = false;
//         }
//         else if(col.CompareTag("Player") && floor3Active == true)
//         {   
//             floor3.SetActive(false);
//             floor3Active = false;
//         }
//          else if(col.CompareTag("Player") && floor4Active == true)
//         {
//             floor4.SetActive(false);
//             floor4Active = false;
//         }
//     }
// }
