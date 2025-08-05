using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using TMPro;
using Unity.Services.Lobbies.Models;
using Unity.Networking.Transport.Relay;
using Unity.Netcode.Transports.UTP;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class TestRelay : NetworkBehaviour
{


    [SerializeField] private string joinCode;
    [SerializeField] private TextMeshProUGUI codeObject;
    [SerializeField] private TextMeshProUGUI codeObjectClient;
    [SerializeField] private GameObject lobby;
    [SerializeField] private GameObject lobbyClient;
    [SerializeField] private GameObject hostName;
    [SerializeField] private GameObject clientNameScreen;
    [SerializeField] private GameObject players;
    [SerializeField] private GameObject nameRequired;
    [SerializeField] private GameObject playerMax;
    [SerializeField] private TMP_InputField joinCodeInput;
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField clientNameInput;


    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI clientName;

   [SerializeField] private bool isPrivate = false;


   // public NetworkVariable<string> HostPlayerName = new NetworkVariable<string>(string.Empty, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

       // HostPlayerName.OnValueChanged += OnHostPlayerNameChanged;

    }

    private void OnHostPlayerNameChanged(string oldName, string newName)
    {
        if (NetworkManager.Singleton.IsHost)
        {
            playerName.text = newName; // Host updates their own UI
        }
        else
        {
            playerName.text = newName; // Client shows host's name in host name UI
        }
    }

    //async void Update()
    //{
    //    await UnityServices.InitializeAsync();
    //    //playerName.text = nameInput.text.Trim();
       

    //    int connectedClients = NetworkManager.Singleton.ConnectedClients.Count;

    //    if (connectedClients >= 1)
    //    {
    //        LockGame();
    //    }
    //    else if (connectedClients < 1)
    //    {
    //        UnlockGame();
    //    }

    //}


    public async void CreateRelay()
    {

        if (string.IsNullOrWhiteSpace(nameInput.text))
        {
            Debug.Log("Input is empty.");
            nameRequired.SetActive(true);
            return;
        }
        else
        {
            Debug.Log("Input is not empty: " + nameInput.text);
            nameRequired.SetActive(false);

        }
       


        try
        {
           Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);

           joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

          //  RelayServerData relayServerData = new RelayServerData();

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(
                allocation.RelayServer.IpV4,
                (ushort)allocation.RelayServer.Port,
                allocation.AllocationIdBytes,
                allocation.Key,
                allocation.ConnectionData);

            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.NetworkConfig.ConnectionApproval = true;

            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;

            Debug.Log(joinCode);

            playerName.text = nameInput.text.Trim();

            //SendPlayerNameServerRpc(nameInput.text.Trim(), NetworkManager.Singleton.LocalClientId);
            //PlayerPrefs.SetString("PlayerName", nameInput.text); // For host


            // PlayerPrefs.SetString("PlayerName", nameInput.text); // For host

            hostName.SetActive(false);
            lobby.SetActive(true);
            players.SetActive(true);
            codeObject.text = joinCode;
           // UnlockGame();

        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }

   


    private async void JoinRelay(string joinCode)
    {
        try
        {
           
            Debug.Log("Joining relay with " + joinCode);
           JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            // RelayServerData relayServerData = new RelayServerData();

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetClientRelayData(
                joinAllocation.RelayServer.IpV4,
                (ushort)joinAllocation.RelayServer.Port,
                joinAllocation.AllocationIdBytes,
                joinAllocation.Key,
                joinAllocation.ConnectionData,
                joinAllocation.HostConnectionData);

            
            NetworkManager.Singleton.NetworkConfig.ConnectionApproval = true;

            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartClient();
         


            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;

           

            clientName.text = clientNameInput.text.Trim();

            SendPlayerNameServerRpc(clientNameInput.text.Trim(), NetworkManager.Singleton.LocalClientId);
            PlayerPrefs.SetString("PlayerName", clientNameInput.text); // For client

            

            players.SetActive(true);
            clientNameScreen.SetActive(false);
            lobbyClient.SetActive(true);
            codeObjectClient.text = joinCode;

           
           


        }
        catch (RelayServiceException e) 
        {
            Debug.Log(e);
        }
    }

    public void JoinRelayFromInput()
    {
        if (string.IsNullOrWhiteSpace(clientNameInput.text))
        {
            Debug.Log("Input is empty.");
            nameRequired.SetActive(true);
            return;
        }
        else
        {
            Debug.Log("Input is not empty: " + clientNameInput.text);
            nameRequired.SetActive(false);

        }
      

        string inputCode = joinCodeInput.text.Trim();
 
            JoinRelay(inputCode);
        
        
    }


    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {

        //response.CreatePlayerObject = false;


        //response.Approved = true;


        //response.Position = Vector3.zero;
        //response.Rotation = Quaternion.identity;
      //  int connectedClients = NetworkManager.Singleton.ConnectedClients.Count;

        // Only allow 1 client to connect (host is already running)
      //  if (connectedClients >= 1 || isPrivate)
      //  {
         //   Debug.Log("Connection rejected: max clients reached or lobby is private.");
         //   response.Approved = false;
           // lobbyClient.SetActive(false);
        //    return;
       // }

        response.CreatePlayerObject = false;
        response.Approved = true;
        response.Position = Vector3.zero;
        response.Rotation = Quaternion.identity;
    }


    public void StopHost()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.Shutdown();
            Debug.Log("Host stopped.");
            lobby.SetActive(false);
            players.SetActive(false);
           // UnlockGame();
        }
    }

    public void LoadGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {

            int connectedClients = NetworkManager.Singleton.ConnectedClients.Count;

            if (connectedClients > 2)
            {
                Debug.Log("Too many clients");
                playerMax.SetActive(true);
                return;
            }
            
            NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);


        }
    }


    public void LeaveClient()
    {
        if (NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsHost)
        {
           // UnlockGame();
            NetworkManager.Singleton.Shutdown();

            lobbyClient.SetActive(false);
            players.SetActive(false);


        }
    }


   
    public void LockGame()
    {
        isPrivate = true;
        Debug.Log("Game is now private. No new players can join.");
    }

    public void UnlockGame()
    {
        isPrivate = false;
        Debug.Log("Game is now Public.");
    }



    void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} connected.");

        // Only do this if we're the client and it's our own connection
        if (clientId == NetworkManager.Singleton.LocalClientId && !NetworkManager.Singleton.IsHost)
        {
            SendPlayerNameServerRpc(clientNameInput.text.Trim(), clientId);
            Debug.Log("Sent client name to server: " + clientNameInput.text.Trim());
        }

        LockGame(); // Optional, depending on your design
    }

    private void OnClientDisconnected(ulong clientId)
    {
        int clientCount = NetworkManager.Singleton.ConnectedClientsList.Count;

        // Exclude host from the count (host is usually clientId 0)
        if (clientCount <= 1) // Only host remains
        {
            Debug.Log("All clients disconnected. Unlocking the game.");
            UnlockGame();

            // Optional: Resubscribe to allow more clients to join
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        }
    }


    public void ShowName()
    {
        hostName.SetActive(true);
    }

    public void ShowClientName()
    {
        clientNameScreen.SetActive(true);
    }



    [ServerRpc(RequireOwnership = false)]
    public void SendPlayerNameServerRpc(string playerName, ulong clientId)
    {
        // Broadcast to all clients to update UI
        UpdatePlayerNameClientRpc(playerName, clientId);
    }


    [ClientRpc]
    private void UpdatePlayerNameClientRpc(string playerNamee, ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            // This is your own name; update your own UI
            if (NetworkManager.Singleton.IsHost)
            {
                playerName.text = playerNamee; // host name UI
            }
            else
            {
                clientName.text = playerNamee; // client name UI
            }
        }
        else
        {
            // This is the other player’s name
            if (NetworkManager.Singleton.IsHost)
            {
                clientName.text = playerNamee; // host sees client’s name
            }
            else
            {
                playerName.text = playerNamee; // client sees host’s name
            }
        }
    }


}
