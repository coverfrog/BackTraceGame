using Cf.CSteam;
using UnityEngine;

public class SteamTest : MonoBehaviour
{
    private void Start()
    {
        SteamManager.Instance.OnActNetworkSpawn += OnNetworkSpawn;
    }

    [ContextMenu("> Host Start")]
    public void HostStart()
    {
        SteamManager.Instance.StartHost();
    }

    public void ClientStart()
    {
        
    }
    
    private void OnNetworkSpawn()
    {
        Debug.Log("네트워크 접속");
    }
}
