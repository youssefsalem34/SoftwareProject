using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using TMPro;
using Unity.Services.Lobbies.Models;

public class TestRelay : MonoBehaviour
{


    [SerializeField] private string joinCode;
    [SerializeField] private TextMeshProUGUI codeObject;
    [SerializeField] private GameObject lobby;
    [SerializeField] private TMP_InputField joinCodeInput;
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

            Debug.Log(joinCode);
            lobby.SetActive(true);
            codeObject.text = joinCode;

        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }


   public async void JoinRelay(string joinCode)
    {
        try
        {
            Debug.Log("Joining relay with " + joinCode);
            await RelayService.Instance.JoinAllocationAsync(joinCode);

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
}
