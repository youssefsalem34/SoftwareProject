using UnityEngine;

public class TPplayer : MonoBehaviour
{
    [SerializeField]private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if(player == null)
        {
            Debug.Log("No Player To Teleport");
        }
        else if(player != null)
        {
            player.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
