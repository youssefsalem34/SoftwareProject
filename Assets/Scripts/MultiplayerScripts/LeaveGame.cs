using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LeaveGamee()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.Shutdown();
            // Load main menu scene for host
            SceneManager.LoadScene(0);
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            NetworkManager.Singleton.Shutdown();
            // Load main menu scene for client
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.LogWarning("Not connected to a network session.");
        }
    }
}
