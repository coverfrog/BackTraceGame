using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AvenuePlayerGroup : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private AssetReference playerReference;

    [Header("Debug View")]
    [SerializeField] private AvenuePlayer playerPrefab;

    private bool _isInit;
    
    public void Init(Action onComplete)
    {
        StartCoroutine(CoInit(onComplete));
    }
    
    private IEnumerator CoInit(Action onComplete)
    {
        const int initTarget = 1;

        int initCount = 0;
        
        InitPrefab(() => ++initCount);
        
        while (initCount < initTarget) yield return null;
        
        onComplete?.Invoke();
        
        _isInit = true;
    }
    
    private void InitPrefab(Action onComplete)
    {
        bool exist = playerReference != null && playerReference.RuntimeKeyIsValid();

        if (!exist)
        {
#if UNITY_EDITOR
            Debug.Assert(false,"No player reference found");
#endif
        }

        Addressables.LoadAssetAsync<GameObject>(playerReference).Completed += (op) =>
        {
            if (op.Status != AsyncOperationStatus.Succeeded)
            {
                return;
            }
          
            if (op.Result.TryGetComponent(out playerPrefab))
            {
                onComplete?.Invoke();
            }

            else
            {
#if UNITY_EDITOR
                Debug.Assert(false,"Slot prefab is Not Have Slot Component");
#endif
            }
        };
    }
}