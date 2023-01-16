using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public int CointCount = 0;

    public void CoinCollected() 
    {
        CointCount++;
    }
}
