using UnityEngine;

public class ShieldMechanic : MonoBehaviour
{
    public bool shieldOn;
    public bool shieldOff;

    [SerializeField] private GameObject shield;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnShieldOn();
    }


    void TurnShieldOn()
    {
        if (shieldOn)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }
}
