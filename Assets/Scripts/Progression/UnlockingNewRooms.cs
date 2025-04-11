// using UnityEngine;

// public class UnlockingNewRooms : MonoBehaviour
// {
//      public GameObject floor2;
//     public GameObject floor3;
//     public GameObject floor4;
//     public GameObject floor5;

//     public GameObject player;
//     public AttributeManager playerRooms;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Awake()
//     {
//          floor2.SetActive(false);
//         floor3.SetActive(false);
//         floor4.SetActive(false);
//         floor5.SetActive(false);
//     }
//     void Start()
//     {
        
        
       
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         player = GameObject.Find("Player");
//         if (player = null)
//         {
//             Debug.Log("Cant find player");
//             player = GameObject.Find("Player");
//         }
//         else if( player != null)
//         {
//             playerRooms = player.GetComponent<AttributeManager>();
//             ControlRooms();
//         }
//         else{
            
//         }

       
//     }

//     void ControlRooms()
//     {
//          if(playerRooms.roomsCount == 1)
//         {
//                     floor2.SetActive(true);

//         }
//         else if(playerRooms.roomsCount == 2)
//         {
//                     floor3.SetActive(true);

//         }
//         else if(playerRooms.roomsCount == 3)
//         {
//             floor4.SetActive(true);
//         }
//         else if((playerRooms.roomsCount == 4))
//         {
//             floor5.SetActive(true);
//         }
//     }
// }
