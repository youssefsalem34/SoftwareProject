using Unity.Netcode;
using TMPro;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public NetworkVariable<string> PlayerName = new NetworkVariable<string>("");

    [SerializeField] private TextMeshProUGUI playerNameUI;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            // Set the player name from local input
            string localName = PlayerPrefs.GetString("PlayerName", "Unknown");
            PlayerName.Value = localName;
        }

        // Subscribe to value changes to update UI
        PlayerName.OnValueChanged += OnNameChanged;

        // Also update immediately
        UpdateNameUI(PlayerName.Value);
    }

    private void OnNameChanged(string oldName, string newName)
    {
        UpdateNameUI(newName);
    }

    private void UpdateNameUI(string name)
    {
        if (playerNameUI != null)
        {
            playerNameUI.text = name;
        }
    }

    public override void OnNetworkDespawn()
    {
        PlayerName.OnValueChanged -= OnNameChanged;
    }
}
