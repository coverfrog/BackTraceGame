using System;
using System.Collections;
using Cf.CBoard;
using Cf.CCard;
using UnityEngine;

public class Avenue : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Board mBoard;
    [SerializeField] private CardHandler mCardHandler;
    [SerializeField] private AvenuePlayerGroup mPlayerGroup;

    public void Init(Action onComplete)
    {
        StartCoroutine(CoInit(onComplete));
    }

    private IEnumerator CoInit(Action onComplete)
    {
        const int initTarget = 2;

        int initCount = 0;
        
        mPlayerGroup.Init(() => ++initCount);
        mBoard.Init(() => ++initCount);
        
        while (initCount < initTarget) yield return null;
        
        onComplete?.Invoke();
    }
    
    public void AddPlayer(bool isMine, bool isPlayer, ulong id)
    {
        mPlayerGroup.AddPlayer(isMine, isPlayer, id);
    }
}
