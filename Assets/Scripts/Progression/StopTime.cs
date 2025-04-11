
using UnityEngine;

public class StopTime : MonoBehaviour
{
    private bool pauseGame;
    private bool startGame;
    [SerializeField] private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 0f;
        player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if(player != null)
        {
            Time.timeScale = 1f;
        }
        else
        {

        }
    }
}

