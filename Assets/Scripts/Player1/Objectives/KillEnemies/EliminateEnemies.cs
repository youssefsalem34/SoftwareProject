using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateEnemies : MonoBehaviour
{
  public GameObject door;
  public OpenDoor doorscript;
    public List<GameObject> enemiesKilled = new List<GameObject>();
  //  public GameObject enemies;
    
    public int numberOfEnemiesKilled;
    public int howManyEnemies;
    public GameObject floor;
    public DetectPlayer detectScript;
    // Start is called before the first frame update
    void Start()
    {
          // if(enemies != null)
      //  {
           // enemies = GameObject.FindWithTag("Enemy");
          //  door = GameObject.Find("DoorFront");
            doorscript = door.GetComponent<OpenDoor>();
        // }
        detectScript = floor.GetComponent<DetectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
      
      if (numberOfEnemiesKilled >= howManyEnemies)
      {
        //Logic to unlock the next room here
        doorscript.openDoor = true;
          detectScript.roomDone = true;
        }
        
    }
}
