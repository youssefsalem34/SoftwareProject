using UnityEngine;

public class CollectSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool collect;
    public AudioSource collectSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collect)
        {
            collectSound.Play();
            collect = false;
        }
    }
}
