using System.Collections;
using Cf.CSteam;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class SceneGame : SceneHandler
{
    [FormerlySerializedAs("gameAvenue")]
    [Header("References")]
    [SerializeField] private Avenue avenue;
    
    public override IEnumerator Start()
    {
        yield return base.Start();

        const int initTarget = 1;

        int initCount = 0;
        
        avenue.Init(() => ++initCount);

        while (initCount < initTarget) yield return null;

#if UNITY_EDITOR
        Debug.Log("Init Complete");
#endif
        
        avenue.AddPlayer(true, true,1004);
        avenue.AddPlayer(false, false,777);
    }
}
