using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private TextMeshProUGUI CoinText;

    private void Start()
    {
        CoinText = GetComponent<TextMeshProUGUI>();
    }

    // sets coin counter text to current number of coins player has
    public void SetCoinText(PlayerCollectibles Collectibles) 
    {
        CoinText.text = Collectibles.CointCount.ToString();
    }
}
