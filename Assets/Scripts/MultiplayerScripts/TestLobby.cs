using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using System.Collections.Generic;


public class TestLobby : MonoBehaviour
{


    private Lobby hostLobby;
    private float heartBeatTimer;
    private string playerName = "Chloe";
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

    private void Update()
    {
        HandleLobbyHearbeat();
    }

    private async void CreateLobby()
    {
        try
        {
            string lobbyName = "MyLobby";
            int maxPlayers = 4;

            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = true,

                Player = GetPlayer()
            };
            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

            hostLobby = lobby;

            Debug.Log("Created Lobby " + lobby.Name + " " + lobby.MaxPlayers);
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
     
    }


    private async void ListLobbies()
    {

        try
        {
            QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync();


            foreach (Lobby lobby in queryResponse.Results)
            {
                Debug.Log(lobby.Name + " " + lobby.MaxPlayers);
            }

        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }


    private async void JoinLobbyByCode(string lobbyCode)
    {

        try
        {

            JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions
            {
                Player = GetPlayer()
            };
            Lobby joinedLobby = await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode, joinLobbyByCodeOptions);
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
      
    }

    private Player GetPlayer()
    {
        return  new Player
        {

            Data = new Dictionary<string, PlayerDataObject>
                    {
                        {
                            "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName)
                        }
                    }
        };
    }

    private async void HandleLobbyHearbeat()
    {
        if (hostLobby != null)
        {
            heartBeatTimer -= Time.deltaTime;
            if (heartBeatTimer < 0)
            {
                float heartBeatTimerMax = 15;
                heartBeatTimer = heartBeatTimerMax;

               await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
            }
        }
    }


    private void PrintPlayers(Lobby lobby)
    {
        foreach (Player player in lobby.Players)
        {

        }
    }


    //private void UpdateLobbyGameMode(string gameMode)
    //{
    //    LobbyService.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
    //        {
    //        Data = new Dictionary<string, DataObject>
    //        {
    //            { "" }
    //        }
    //    });
    //}
}
