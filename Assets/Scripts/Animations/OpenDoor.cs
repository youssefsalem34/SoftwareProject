using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool openDoor;
     private Animator openAnimation;
     [SerializeField]private GameObject objec1;
     [SerializeField]private GameObject objec2;
     [SerializeField]private GameObject objec3;
     [SerializeField]private GameObject payload;
     [SerializeField]private AudioSource soundEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(openDoor )
        {
            soundEffect.Play();
            openAnimation.SetBool("openDoor", true);
            
        }

        if(openDoor && objec1.activeSelf)
        {
            objec1.SetActive(false);
        }
        else if (openDoor && objec2.activeSelf)
        {
            objec2.SetActive(false);
        }
        else if(openDoor && objec3.activeSelf)
        {
            objec3.SetActive(false);
            payload.SetActive(false);
        }
    }
}
