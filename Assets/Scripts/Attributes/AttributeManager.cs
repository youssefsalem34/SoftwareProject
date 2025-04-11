using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttributeManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField]private float playerHealth;
   public float enemyHealth;
    [SerializeField]private int roomsCount;

    public bool resetHealth;

    private void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = playerHealth;
        }
        
    }

    private void Update()
    {
        if (healthSlider != null)
        {
            healthSlider.value = playerHealth;
        }


        if (resetHealth)
        {
            playerHealth = 500;
            resetHealth = false;
        }
        
    }


    public float CheckHealth()
    {
        return playerHealth;
    }


    public void ReduceHealth(float amount)
        {
            playerHealth -= amount;
        }
    public void IncreaseHealth(float amount)
    {
        playerHealth = amount;
    }

    public void ReduceEnemyHealth(float amount)
        {
            enemyHealth -= amount;
        }
        public void IncreaseRoom(int amount)
        {
            roomsCount += amount;
        }
    public int RoomCheck()
    {
        return roomsCount;
    }

    }
