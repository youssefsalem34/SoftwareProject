using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class TPplayer : NetworkBehaviour
{
    [SerializeField]private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ulong hostClientId = NetworkManager.Singleton.LocalClientId;
        //GameObject player = Instantiate(NetworkManager.Singleton.NetworkConfig.PlayerPrefab, this.transform.position, Quaternion.identity);
        //player.GetComponent<NetworkObject>().SpawnAsPlayerObject(hostClientId);

        //if (NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsHost)
        //{
        //    NetworkManager.Singleton.GetComponent<TestRelay>().RequestSpawnPlayerServerRpc();
        //}


        //if (IsServer)
        //{
        //    // Spawn the player object for each connected client, including host
        //    foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        //    {
        //        Debug.Log("SpawnerThePLAYAAAAA");
        //        GameObject newPlayer = Instantiate(NetworkManager.Singleton.NetworkConfig.PlayerPrefab, transform.position, Quaternion.identity);
        //        newPlayer.GetComponent<NetworkObject>().SpawnAsPlayerObject(client.ClientId);
        //    }
        //}

        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            GameObject player = Instantiate(NetworkManager.Singleton.NetworkConfig.PlayerPrefab, Vector3.zero, Quaternion.identity);
            player.GetComponent<NetworkObject>().SpawnAsPlayerObject(client.ClientId);
            Debug.Log($"Spawned player for client {client.ClientId}");
        }
    }

    [ServerRpc]
    private void RequestSpawnPlayerServerRpc(ServerRpcParams rpcParams = default)
    {
        GameObject player = Instantiate(NetworkManager.Singleton.NetworkConfig.PlayerPrefab, transform.position, Quaternion.identity);
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(rpcParams.Receive.SenderClientId);
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
       // if (!IsServer) return; // Only the server should spawn players

        
    }
}

