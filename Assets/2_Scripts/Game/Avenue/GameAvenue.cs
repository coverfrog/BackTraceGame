using System;
using System.Collections;
using Cf.CCard;
using Cf.CSteam;
using UnityEngine;

namespace Avenue
{
    public class GameAvenue : Game
    {
        [Header("[ References ]")]
        [SerializeField] private CardDeckBehaviour mDeck;
        [SerializeField] private CardSpawnBehaviour mSpawn;

        private IEnumerator Start()
        {
            yield return CoWaitInitialize();
        }

        private IEnumerator CoWaitInitialize()
        {
            yield return new WaitUntil(() =>
                SteamManager.Instance.NetworkManager != null);
            
            yield return new WaitUntil(() =>
                mDeck.IsInitialized && 
                mSpawn.IsInitialized);
        
            mDeck?.Stack();
        }

        [ContextMenu("> Start Host")]
        public void StartHost()
        {
            SteamManager.Instance.StartHost();
        }
    }
}
