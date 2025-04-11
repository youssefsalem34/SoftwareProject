using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public bool isClose;
    private Animator closeAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isClose)
        {
            closeAnimation.SetBool("CloseDoor", true);
        }
    }
}
