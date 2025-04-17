using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private PlayerDeath deathScript;
    [SerializeField] private float time;
    [SerializeField] private float resetTimer;
    [SerializeField] private TMP_Text timerDisplay;
    [SerializeField] private GameObject secondObj;
    [SerializeField] private bool timerDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //Timerr();

        if (secondObj.gameObject.activeSelf)
        {
            time = time - Time.deltaTime;
            UpdateTimerDisplay();
        }
        //else
        //{
        //    time = resetTimer;
        //}


        if (time <= 0)
        {
            timerDone = true;
        }

        if (timerDone)
        {
            deathScript.playerDead = true;
            
            timerDone = false;
        }
    }



    void Timerr()
    {
        
    }


    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(time / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(time % 60); // Calculate seconds
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Display in "MM:SS" format
    }


    public void ResetTime()
    {
        time = resetTimer;
    }
}
