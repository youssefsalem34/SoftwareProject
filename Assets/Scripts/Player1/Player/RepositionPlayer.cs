using UnityEngine;

public class RepositionPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
             player.transform.position = this.transform.position;

        }
    }
}
