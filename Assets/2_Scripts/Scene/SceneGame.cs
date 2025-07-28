using System.Collections;
using Cf.CSteam;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class SceneGame : SceneHandler
{
    [Header("References")]
    [SerializeField] private Avenue avenue;

    public override IEnumerator Start()
    {
        
        return base.Start();
    }
}
