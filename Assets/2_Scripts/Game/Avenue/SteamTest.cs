using Cf.CSteam;
using UnityEngine;

public class SteamTest : MonoBehaviour
{
    [ContextMenu("> Host Start")]
    public void HostStart()
    {
        SteamManager.Instance.StartHost();
    }

    public void ClientStart()
    {
        
    }
}
