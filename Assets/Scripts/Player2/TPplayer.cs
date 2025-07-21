using Unity.Netcode;
using UnityEditor.PackageManager;
using UnityEngine;

public class TPplayer : MonoBehaviour
{
    [SerializeField]private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ulong hostClientId = NetworkManager.Singleton.LocalClientId;
        GameObject player = Instantiate(NetworkManager.Singleton.NetworkConfig.PlayerPrefab,this.transform.position, Quaternion.identity);
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(hostClientId); // Set owner
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
