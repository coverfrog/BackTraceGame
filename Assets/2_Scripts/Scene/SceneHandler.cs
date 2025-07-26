using System.Collections;
using Cf.CSteam;
using UnityEngine;

public abstract class SceneHandler : MonoBehaviour
{
    public virtual IEnumerator Start()
    {
        while(!SteamManager.Instance.IsLoaded)
        {
            yield return null;
        }
    }
}
