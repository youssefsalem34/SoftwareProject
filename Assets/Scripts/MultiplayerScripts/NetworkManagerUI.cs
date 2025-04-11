using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using Unity.Netcode.Transports.UTP;
using TMPro;

public class NetworkManagerUI : NetworkBehaviour
{
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private TMP_InputField ipInputField;
    [SerializeField] private UnityTransport transport;

    private void Awake()
    {
        // Ensure transport reference
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        hostBtn.onClick.AddListener(() =>
        {
            SetHostIpAddress();  // Set IP before starting host
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
        });

        clientBtn.onClick.AddListener(() =>
        {
            SetIpAddress();  // Set client IP before connecting
            NetworkManager.Singleton.StartClient();
        });

        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Debug.Log("Client Connected: " + id);
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            Debug.LogError("Client Disconnected: " + id);
        };
    }

    public void SetIpAddress()
    {
       // if (ipInputField != null && !string.IsNullOrWhiteSpace(ipInputField.text))
        //{
            transport.ConnectionData.Address = ipInputField.text;
            transport.ConnectionData.Port = 7777;  // Ensure host & client use the same port
            Debug.Log("IP Address set to: " + transport.ConnectionData.Address);
       // }
       // else
      //  {
       //     Debug.LogWarning("IP Address field is empty. Please enter a valid address.");
       // }
    }


    public void SetHostIpAddress()
    {
     //   if (ipInputField != null && !string.IsNullOrWhiteSpace(ipInputField.text))
      //  {
            transport.ConnectionData.Address = "0.0.0.0";  // Ensures host listens on all interfaces
            transport.ConnectionData.Port = 7777;
            transport.ConnectionData.ServerListenAddress = "0.0.0.0"; // For external connections

            Debug.Log("IP Address set to: " + transport.ConnectionData.Address);
     //   }
      //  else
      //  {
       //     Debug.LogWarning("IP Address field is empty. Please enter a valid address.");
      //  }
    }
}
