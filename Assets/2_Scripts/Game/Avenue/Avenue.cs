using System;
using System.Collections;
using System.Collections.Generic;
using Cf.CBoard;
using Cf.CSteam;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Avenue : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Board board;
    [SerializeField] private AvenuePlayerGroup playerGroup;

    public void Init(Action onComplete)
    {
        StartCoroutine(CoInit(onComplete));
    }

    private IEnumerator CoInit(Action onComplete)
    {
        const int initTarget = 2;

        int initCount = 0;
        
        playerGroup.Init(() => ++initCount);
        board.Init(() => ++initCount);
        
        while (initCount < initTarget) yield return null;
        
        onComplete?.Invoke();
    }
}
