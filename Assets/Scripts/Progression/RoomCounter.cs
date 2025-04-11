using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCounter : MonoBehaviour
{
   // public GameObject player;
    public AttributeManager rooms;
    public bool hasEntered = false; // Track if the player has already entered this room

    void Start()
    {
        //   player = GameObject.Find("Player");
        // if (player != null)
        // {
        //     rooms = player.GetComponent<AttributeManager>();
        // }
        // else
        // {
        //     Debug.LogError("Player object not found. Make sure it has the tag 'Player'.");
        // }
    }

    void Update()
    {
        // If you have logic to execute every frame, add it here.
      
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && !hasEntered) // Check if it's the player and they haven't entered yet
        {
            hasEntered = true; // Mark as entered
            AttributeManager attributeManager = col.GetComponent<AttributeManager>();
            if (attributeManager != null)
        {
            // Call IncreaseRoom if the AttributeManager component was found
            attributeManager.IncreaseRoom(1);
        }
        else
        {
            Debug.LogWarning("AttributeManager component not found on the Player object.");
        }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            hasEntered = false; // Reset when the player exits
        }
    }
}