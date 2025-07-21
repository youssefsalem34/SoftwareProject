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
    [SerializeField] private TMP_InputField joinCodeInput;

    private bool isPrivate = false;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

   

    // Update is called once per frame
    public async void CreateRelay()
    {
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

         
            Debug.Log(joinCode);
            lobby.SetActive(true);
            codeObject.text = joinCode;
            UnlockGame();

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

            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.NetworkConfig.ConnectionApproval = true;

            NetworkManager.Singleton.StartClient();
            lobbyClient.SetActive(true);
            codeObjectClient.text = joinCode;
            LockGame();

        }
        catch (RelayServiceException e) 
        {
            Debug.Log(e);
        }
    }

    public void JoinRelayFromInput()
    {
        string inputCode = joinCodeInput.text.Trim();
        JoinRelay(inputCode);
    }


    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {

        //response.CreatePlayerObject = false;


        //response.Approved = true;


        //response.Position = Vector3.zero;
        //response.Rotation = Quaternion.identity;
        if (isPrivate)
        {
            Debug.Log("Connection rejected: game is private.");
            response.Approved = false;
            return;
        }

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
            UnlockGame();
        }
    }

    public void LoadGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);


        }
    }


    public void LeaveClient()
    {
        if (NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsHost)
        {
            LockGame();
            NetworkManager.Singleton.Shutdown();

            lobbyClient.SetActive(false);


            
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

}
