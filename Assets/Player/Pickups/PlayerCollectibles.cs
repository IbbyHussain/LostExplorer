using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollectibles : MonoBehaviour
{
    public int CointCount = 0;

    public UnityEvent<PlayerCollectibles> OnCoinPickup;

    public void CoinCollected() 
    {
        CointCount++;

        // when coin is picked up UI will update
        OnCoinPickup.Invoke(this);
    }
}
