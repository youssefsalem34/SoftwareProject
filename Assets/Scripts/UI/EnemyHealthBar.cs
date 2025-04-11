using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private AttributeManager attributeManager; // Reference to the AttributeManager
    [SerializeField] private Slider enemyHealthSlider;          // Reference to the Slider component
    [SerializeField] private float maxEnemyHealth;       // Maximum health for the enemy

    private void Start()
    {
        // Initialize the slider
        if (enemyHealthSlider != null)
        {
            enemyHealthSlider.maxValue = maxEnemyHealth;
            enemyHealthSlider.value = attributeManager.enemyHealth;
        }
    }

    private void Update()
    {
        // Sync the slider value with enemy health from AttributeManager
        if (enemyHealthSlider != null && attributeManager != null)
        {
            enemyHealthSlider.value = attributeManager.enemyHealth;
        }
    }
}