using UnityEngine;

public class AvenuePlayer : MonoBehaviour
{
    [SerializeField] private bool mIsMine;
    [SerializeField] private bool mIsPlayer;
    [SerializeField] private ulong mId;
    
    public void Init(bool isMine, bool isPlayer, ulong id)
    {
        mIsMine = isMine;
        mIsPlayer = isPlayer;
        mId = id;
    }
}
