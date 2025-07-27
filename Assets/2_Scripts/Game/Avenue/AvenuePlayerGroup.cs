using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AvenuePlayerGroup : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private AssetReference playerReference;

    [Header("Debug View")]
    [SerializeField] private AvenuePlayer playerPrefab;
    [SerializeField] private List<AvenuePlayer> playerList = new List<AvenuePlayer>();

    public void Init(Action onComplete)
    {
        StartCoroutine(CoInit(onComplete));
    }
    
    private IEnumerator CoInit(Action onComplete)
    {
        const int initTarget = 1;

        int initCount = 0;
        
        InitPrefab<AvenuePlayer>(playerReference, (result) =>
        {
            playerPrefab = result;
            
            ++initCount;
        });
        
        while (initCount < initTarget) yield return null;
        
        onComplete?.Invoke();
    }
    
    private void InitPrefab<T>(AssetReference reference, Action<T> onComplete) 
    {
        bool exist = reference != null && reference.RuntimeKeyIsValid();

        if (!exist)
        {
#if UNITY_EDITOR
            Debug.Assert(false,"No reference found");
#endif
        }

        Addressables.LoadAssetAsync<GameObject>(reference).Completed += (op) =>
        {
            if (op.Status != AsyncOperationStatus.Succeeded)
            {
                return;
            }
          
            if (op.Result.TryGetComponent(out T t))
            {
                onComplete?.Invoke(t);
            }

            else
            {
#if UNITY_EDITOR
                Debug.Assert(false,"Slot prefab is Not Have Slot Component");
#endif
            }
        };
    }

    public void AddPlayer(bool isMine, bool isPlayer, ulong id)
    {
       AvenuePlayer player = Instantiate(playerPrefab, transform);
       player.gameObject.name = $"Player[ {(isMine ? "Mine" : "Other")} ] : {id}";
       player.Init(isMine, isPlayer, id);
       
       playerList.Add(player);
    }
}